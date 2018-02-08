using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnityEngine.FrameRecorder.Input
{
    public class AdamBeautyInput : BaseRenderTextureInput
    {
        Shader superShader;
        Shader accumulateShader;
        Shader normalizeShader;

        RenderTexture m_renderRT;
        RenderTexture[] m_accumulateRTs = new RenderTexture[2];
        int m_renderWidth, m_renderHeight, m_outputWidth, m_outputHeight;

        Material m_superMaterial;
        Material m_accumulateMaterial;
        Material m_normalizeMaterial;

        class HookedCamera
        {
            public Camera camera;
            public RenderTexture textureBackup;
        }

        List<HookedCamera> m_hookedCameras;

        Vector2[] m_samples;

        AdamBeautyInputSettings adamSettings
        {
            get { return (AdamBeautyInputSettings)settings; }
        }

        void GenerateSamplesMSAA(Vector2[] samples, ESuperSamplingCount sc)
        {
            switch (sc)
            {
                case ESuperSamplingCount.x1:
                    samples[0] = new Vector2(0.0f, 0.0f);
                    break;
                case ESuperSamplingCount.x2:
                    samples[0] = new Vector2(4.0f, 4.0f);
                    samples[1] = new Vector2(-4.0f, -4.0f);
                    break;
                case ESuperSamplingCount.x4:
                    samples[0] = new Vector2(-2.0f, -6.0f);
                    samples[1] = new Vector2(6.0f, -2.0f);
                    samples[2] = new Vector2(-6.0f, 2.0f);
                    samples[3] = new Vector2(2.0f, 6.0f);
                    break;
                case ESuperSamplingCount.x8:
                    samples[0] = new Vector2(1.0f, -3.0f);
                    samples[1] = new Vector2(-1.0f, 3.0f);
                    samples[2] = new Vector2(5.0f, 1.0f);
                    samples[3] = new Vector2(-3.0f, -5.0f);

                    samples[4] = new Vector2(-5.0f, 5.0f);
                    samples[5] = new Vector2(-7.0f, -1.0f);
                    samples[6] = new Vector2(3.0f, 7.0f);
                    samples[7] = new Vector2(7.0f, -7.0f);
                    break;
                case ESuperSamplingCount.x16:
                    samples[0] = new Vector2(1.0f, 1.0f);
                    samples[1] = new Vector2(-1.0f, -3.0f);
                    samples[2] = new Vector2(-3.0f, 2.0f);
                    samples[3] = new Vector2(4.0f, -1.0f);

                    samples[4] = new Vector2(-5.0f, -2.0f);
                    samples[5] = new Vector2(2.0f, 5.0f);
                    samples[6] = new Vector2(5.0f, 3.0f);
                    samples[7] = new Vector2(3.0f, -5.0f);

                    samples[8] = new Vector2(-2.0f, 6.0f);
                    samples[9] = new Vector2(0.0f, -7.0f);
                    samples[10] = new Vector2(-4.0f, -6.0f);
                    samples[11] = new Vector2(-6.0f, 4.0f);

                    samples[12] = new Vector2(-8.0f, 0.0f);
                    samples[13] = new Vector2(7.0f, -4.0f);
                    samples[14] = new Vector2(6.0f, 7.0f);
                    samples[15] = new Vector2(-7.0f, -8.0f);
                    break;
                default:
                    Debug.LogError("Not expected sample count: " + sc);
                    return;
            }
            const float oneOverSixteen = 1.0f / 16.0f;
            Vector2 halfHalf = new Vector2(0.5f, 0.5f);
            for (int i = 0; i < samples.Length; i++)
            {
                samples[i] = samples[i] * oneOverSixteen + halfHalf;
            }
        }

        public override void BeginRecording(RecordingSession session)
        {
            superShader = Shader.Find("Hidden/Volund/BS4SuperShader");
            accumulateShader = Shader.Find("Hidden/BeautyShot/Accumulate");
            normalizeShader = Shader.Find("Hidden/BeautyShot/Normalize");

            // Below here is considered 'void Start()', but we run it for directly "various reasons".
            if (adamSettings.m_FinalSize > adamSettings.m_RenderSize)
                throw new UnityException("Upscaling is not supported! Output dimension must be smaller or equal to render dimension.");

            // Calculate aspect and render/output sizes
            // Clamp size to 16K, which is the min always supported size in d3d11
            // Force output to divisible by two as x264 doesn't approve of odd image dimensions.
            var aspect = AspectRatioHelper.GetRealAR(adamSettings.m_AspectRatio);
            m_renderHeight = (int)adamSettings.m_RenderSize;
            m_renderWidth = Mathf.Min(16 * 1024, Mathf.RoundToInt(m_renderHeight * aspect));
            m_outputHeight = (int)adamSettings.m_FinalSize;
            m_outputWidth = Mathf.Min(16 * 1024, Mathf.RoundToInt(m_outputHeight * aspect));
            if (adamSettings.m_ForceEvenSize)
            {
                m_outputWidth = (m_outputWidth + 1) & ~1;
                m_outputHeight = (m_outputHeight + 1) & ~1;
            }

            m_superMaterial = new Material(superShader);
            m_superMaterial.hideFlags = HideFlags.DontSave;

            m_accumulateMaterial = new Material(accumulateShader);
            m_accumulateMaterial.hideFlags = HideFlags.DontSave;

            m_normalizeMaterial = new Material(normalizeShader);
            m_normalizeMaterial.hideFlags = HideFlags.DontSave;

            m_renderRT = new RenderTexture(m_renderWidth, m_renderHeight, 24, RenderTextureFormat.DefaultHDR, RenderTextureReadWrite.Linear);
            m_renderRT.wrapMode = TextureWrapMode.Clamp;
            for (int i = 0; i < 2; ++i)
            {
                m_accumulateRTs[i] = new RenderTexture(m_renderWidth, m_renderHeight, 0, RenderTextureFormat.DefaultHDR, RenderTextureReadWrite.Linear);
                m_accumulateRTs[i].wrapMode = TextureWrapMode.Clamp;
                m_accumulateRTs[i].Create();
            }
            var rt = new RenderTexture(m_outputWidth, m_outputHeight, 0, RenderTextureFormat.Default, RenderTextureReadWrite.sRGB);
            rt.Create();
            outputRT = rt;
            m_samples = new Vector2[(int)adamSettings.m_SuperSampling];
            GenerateSamplesMSAA(m_samples, adamSettings.m_SuperSampling);

            m_hookedCameras = new List<HookedCamera>();
        }

        public override void NewFrameStarting(RecordingSession session)
        {
            switch (adamSettings.source)
            {
                case EImageSource.GameDisplay:
                {
                    bool sort = false;

                    // Find all cameras targetting Display
                    foreach (var cam in Resources.FindObjectsOfTypeAll<Camera>())
                    {
                        var hookedCam = m_hookedCameras.Find((x) => cam == x.camera);
                        if (hookedCam != null)
                        {
                            // Should we keep it?
                            if (cam.targetDisplay != 0 || !cam.enabled)
                            {
                                UnityHelpers.Destroy(cam.targetTexture);
                                cam.targetTexture = hookedCam.textureBackup;
                                m_hookedCameras.Remove(hookedCam);
                            }
                            continue;
                        }

                        if (!cam.enabled || !cam.gameObject.activeInHierarchy || cam.targetDisplay != 0)
                            continue;

                        hookedCam = new HookedCamera() { camera = cam, textureBackup = cam.targetTexture };
                        var camRT = new RenderTexture((int)(m_renderWidth * cam.rect.width), (int)(m_renderHeight * cam.rect.height), 24, RenderTextureFormat.DefaultHDR, RenderTextureReadWrite.Linear);
                        cam.targetTexture = camRT;
                        m_hookedCameras.Add(hookedCam);
                        sort = true;
                    }

                    if (sort)
                    {
                        m_hookedCameras = m_hookedCameras.OrderBy(x => x.camera.depth).ToList();
                    }
                    break;
                }
                case EImageSource.MainCamera:
                {
                    var cam = Camera.main;
                    if (m_hookedCameras.Count > 0)
                    {
                        if (m_hookedCameras[0].camera != cam)
                        {
                            m_hookedCameras[0].camera.targetTexture = m_hookedCameras[0].textureBackup;
                            m_hookedCameras.Clear();
                        }
                        else
                            break;
                    }
                    if (!cam.enabled)
                        break;

                    var hookedCam = new HookedCamera() { camera = cam, textureBackup = cam.targetTexture };
                    cam.targetTexture = m_renderRT;
                    m_hookedCameras.Add(hookedCam);
                    break;
                }
                case EImageSource.TaggedCamera:
                    break;
                case EImageSource.RenderTexture:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (m_hookedCameras != null)
                {
                    foreach (var c in m_hookedCameras)
                    {
                        if (c != null)
                        {
                            if (c.camera.rect.width == 1f && c.camera.rect.height == 1f)
                                UnityHelpers.Destroy(c.camera.targetTexture);
                            c.camera.targetTexture = c.textureBackup;
                        }
                    }
                    m_hookedCameras.Clear();
                }

                UnityHelpers.Destroy(m_renderRT);
                foreach (var rt in m_accumulateRTs)
                    UnityHelpers.Destroy(rt);
                UnityHelpers.Destroy(m_superMaterial);
                UnityHelpers.Destroy(m_accumulateMaterial);
                UnityHelpers.Destroy(m_normalizeMaterial);
            }

            base.Dispose(disposing);
        }

        public override void NewFrameReady(RecordingSession session)
        {
            PerformSubSampling();

            if (adamSettings.m_RenderSize == adamSettings.m_FinalSize)
            {
                // Blit with normalization if sizes match.
                m_normalizeMaterial.SetFloat("_NormalizationFactor", 1.0f / (float)adamSettings.m_SuperSampling);
                Graphics.Blit(m_renderRT, outputRT, m_normalizeMaterial);
            }
            else
            {
                // Ideally we would use a separable filter here, but we're massively bound by readback and disk anyway for hi-res.
                m_superMaterial.SetVector("_Target_TexelSize", new Vector4(1f / m_outputWidth, 1f / m_outputHeight, m_outputWidth, m_outputHeight));
                m_superMaterial.SetFloat("_KernelCosPower", adamSettings.m_SuperKernelPower);
                m_superMaterial.SetFloat("_KernelScale", adamSettings.m_SuperKernelScale);
                m_superMaterial.SetFloat("_NormalizationFactor", 1.0f / (float)adamSettings.m_SuperSampling);
                Graphics.Blit(m_renderRT, outputRT, m_superMaterial);
            }
        }

        void ShiftProjectionMatrix(Camera camera, Vector2 sample)
        {
            camera.ResetProjectionMatrix();
            Matrix4x4 projectionMatrix = camera.projectionMatrix;
            float dx = sample.x / m_renderWidth;
            float dy = sample.y / m_renderHeight;
            projectionMatrix.m02 += dx;
            projectionMatrix.m12 += dy;
            camera.projectionMatrix = projectionMatrix;
        }

        bool CameraUsingPartialViewport(Camera cam)
        {
            return cam.rect.width != 1 || cam.rect.height != 1 || cam.rect.x != 0 || cam.rect.y != 0;
        }

        void PerformSubSampling()
        {
            RenderTexture accumulateInto = null;
            m_renderRT.wrapMode = TextureWrapMode.Clamp;
            m_renderRT.filterMode = FilterMode.Point;

            int x = 0;
            Graphics.SetRenderTarget(m_accumulateRTs[0]);
            GL.Clear(false, true, Color.black);

            foreach (var hookedCam in m_hookedCameras)
            {
                var cam = hookedCam.camera;

                for (int i = 0, n = (int)adamSettings.m_SuperSampling; i < n; i++)
                {
                    var oldProjectionMatrix = cam.projectionMatrix;
                    var oldRect = cam.rect;
                    cam.rect  =new Rect(0f,0f,1f,1f);
                    ShiftProjectionMatrix(cam, m_samples[i] - new Vector2(0.5f, 0.5f));
                    cam.Render();
                    cam.projectionMatrix = oldProjectionMatrix;
                    cam.rect = oldRect;

                    accumulateInto = m_accumulateRTs[(x + 1) % 2];
                    var accumulatedWith = m_accumulateRTs[x % 2];
                    m_accumulateMaterial.SetTexture("_PreviousTexture", accumulatedWith);

                    if (CameraUsingPartialViewport(cam))
                    {
                        m_accumulateMaterial.SetFloat("_OfsX", cam.rect.x );
                        m_accumulateMaterial.SetFloat("_OfsY", cam.rect.y );
                        m_accumulateMaterial.SetFloat("_Width", cam.rect.width );
                        m_accumulateMaterial.SetFloat("_Height", cam.rect.height );
                        m_accumulateMaterial.SetFloat("_Scale", cam.targetTexture.width / (float)m_renderRT.width );
                    }
                    else
                    {
                        m_accumulateMaterial.SetFloat("_OfsX", 0 );
                        m_accumulateMaterial.SetFloat("_OfsY", 0 );
                        m_accumulateMaterial.SetFloat("_Width", 1 );
                        m_accumulateMaterial.SetFloat("_Height", 1 );
                        m_accumulateMaterial.SetFloat("_Scale", 1 );
                    }
                    m_accumulateMaterial.SetInt("_Pass", i);
                    Graphics.Blit(cam.targetTexture, accumulateInto, m_accumulateMaterial);
                    x++;
                }
            }

            Graphics.Blit(accumulateInto, m_renderRT);
        }

        void SaveRT(RenderTexture input)
        {
            if (input == null) return;

            var width = input.width;
            var height = input.height;
            
            var tex = new Texture2D(width, height, TextureFormat.RGBA32 , false);
            var backupActive = RenderTexture.active;
            RenderTexture.active = input;
            tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            tex.Apply();
            RenderTexture.active = backupActive;

            byte[] bytes;
            bytes = tex.EncodeToPNG();

            UnityHelpers.Destroy(tex);

            File.WriteAllBytes("Recorder/DebugDump.png", bytes);
        }
    }
}