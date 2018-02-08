using UnityEngine;
using System.Collections;

public class OVRGazePointer : MonoBehaviour
{

    [Tooltip("Should the pointer be hidden when not over interactive objects.")]
    public bool hideByDefault = true;

    [Tooltip("Time after leaving interactive object before pointer fades.")]
    public float showTimeoutPeriod = 1;

    [Tooltip("Time after mouse pointer becoming inactive before pointer unfades.")]
    public float hideTimeoutPeriod = 0.1f;

    [Tooltip("Keep a faint version of the pointer visible while using a mouse")]
    public bool dimOnHideRequest = true;

    [Tooltip("Angular scale of pointer")]
    public float depthScaleMultiplier = 0.03f;

    //[Tooltip("Used for positioning pointer in scene")]
    //public OVRCameraRig cameraRig;

    /// <summary>
    /// Is gaze pointer current visible
    /// </summary>
    public bool hidden { get; private set; }

    /// <summary>
    /// Current scale applied to pointer
    /// </summary>
    public float currentScale { get; private set; }

    /// <summary>
    /// Current depth of pointer from camera
    /// </summary>
    private float depth;
    /// <summary>
    /// How many times position has been set this frame. Used to detect when there are no position sets in a frame.
    /// </summary>
    private int positionSetsThisFrame = 0;
    /// <summary>
    /// Position last frame.
    /// </summary>
    private Vector3 lastPosition;
    /// <summary>
    /// Last time code requested the pointer be shown. Usually when pointer passes over interactive elements.
    /// </summary>
    private float lastShowRequestTime;
    /// <summary>
    /// Last time pointer was requested to be hidden. Usually mouse pointer activity.
    /// </summary>
    private float lastHideRequestTime;


    // How much the gaze pointer moved in the last frame
    private Vector3 _positionDelta;
    public Vector3 positionDelta { get { return _positionDelta; } }

    private static OVRGazePointer _instance;
    public static OVRGazePointer instance
    {
        // If there's no GazePointer already in the scene, instanciate one now.
        get
        {
            if (_instance == null)
            {
                Debug.Log(string.Format("Instanciating GazePointer", 0));
                _instance = (OVRGazePointer)GameObject.Instantiate((OVRGazePointer)Resources.Load("Prefabs/GazePointerRing", typeof(OVRGazePointer)));
            }
            return _instance;
        }

    }

    public float visibilityStrength
    {
        get
        {
            float strengthFromShowRequest;
            if (hideByDefault)
            {
                strengthFromShowRequest = Mathf.Clamp01(1 - (Time.time - lastShowRequestTime) / showTimeoutPeriod);
            }
            else
            {
                strengthFromShowRequest = 1;
            }

            // Now consider factors requesting pointer to be hidden
            float strengthFromHideRequest;
            if (dimOnHideRequest)
            {
                strengthFromHideRequest = (lastHideRequestTime + hideTimeoutPeriod > Time.time) ? 0.1f : 1;
            }
            else
            {
                strengthFromHideRequest = (lastHideRequestTime + hideTimeoutPeriod > Time.time) ? 0 : 1;
            }

            // Hide requests take priority
            return Mathf.Min(strengthFromShowRequest, strengthFromHideRequest);
        }
    }


    private void Awake()
    {
        currentScale = 1;
        // Only allow one instance at runtime.
        if (_instance != null && _instance != this)
        {
            enabled = false;
            DestroyImmediate(this);
            return;
        }

        _instance = this;

    }


    // Update is called once per frame
    void Update()
    {
        // Even if this runs after SetPosition, it will work out to be the same position
        // Keep pointer at same distance from camera rig
        //transform.position = cameraRig.centerEyeAnchor.transform.position + cameraRig.centerEyeAnchor.transform.forward * depth;


        if (visibilityStrength == 0 && !hidden)
        {
            Hide();
        }
        else if (visibilityStrength > 0 && hidden)
        {
            Show();
        }
    }

    /// <summary>
    /// Set position and orientation of pointer
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="normal"></param>
    public void SetPosition(Vector3 pos, Vector3 normal)
    {
        transform.position = pos;

        // Set the rotation to match the normal of the surface it's on. For the other degree of freedom use
        // the direction of movement so that trail effects etc are easier
        Quaternion newRot = transform.rotation;
        newRot.SetLookRotation(normal, (lastPosition - transform.position).normalized);
        transform.rotation = newRot;

        // record depth so that distance doesn't pop when pointer leaves an object
        //depth = (cameraRig.centerEyeAnchor.transform.position - pos).magnitude;

        //set scale based on depth
        currentScale = depth * depthScaleMultiplier;
        transform.localScale = new Vector3(currentScale, currentScale, currentScale);

        positionSetsThisFrame++;
    }

    /// <summary>
    /// SetPosition overload without normal. Just makes cursor face user
    /// </summary>
    /// <param name="pos"></param>
    public void SetPosition(Vector3 pos)
    {
        //SetPosition(pos, cameraRig.centerEyeAnchor.transform.forward);
    }


    void LateUpdate()
    {
        // This happens after all Updates so we know nothing set the position this frame
        if (positionSetsThisFrame == 0)
        {
            // No geometry intersections, so gazing into space. Make the cursor face directly at the camera
            Quaternion newRot = transform.rotation;
            //newRot.SetLookRotation(cameraRig.centerEyeAnchor.transform.forward, (lastPosition - transform.position).normalized);
            transform.rotation = newRot;
        }
        // Keep track of cursor movement direction
        _positionDelta = transform.position - lastPosition;
        lastPosition = transform.position;

        positionSetsThisFrame = 0;
    }

    /// <summary>
    /// Request the pointer be hidden
    /// </summary>
    public void RequestHide()
    {
        if (!dimOnHideRequest)
        {
            Hide();
        }
        lastHideRequestTime = Time.time;
    }

    /// <summary>
    /// Request the pointer be shown. Hide requests take priority
    /// </summary>
    public void RequestShow()
    {
        Show();
        lastShowRequestTime = Time.time;
    }

    private void Hide()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        if (GetComponent<Renderer>())
            GetComponent<Renderer>().enabled = false;
        hidden = true;
    }

    private void Show()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        if (GetComponent<Renderer>())
            GetComponent<Renderer>().enabled = true;
        hidden = false;
    }

}
