using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using VRTK;

public class DrawLineManager : MonoBehaviour {

    private Material activeMat;
	public Material DefaultMat;
    public Material squareWave;
    public Material sawWave;
    public Material cycleWave;
    public Material triangleWave;

    //VRTK Controllers
    //public VRTK_ControllerEvents leftControllerEvents;
    //public VRTK_ControllerEvents rightControllerEvents;
    private GameObject controllerDevice;
    private bool triggerDown = false;

    private MeshLineRenderer currLine;
    private int numClicks = 0;
    private string activeWave;
    //private VRTK_ControllerReference controllerReference;

    private void Start()
    {
        activeWave = "square";
        activeMat = DefaultMat;
        //Setup controller event listeners
        //leftControllerEvents.TriggerClicked += new ControllerInteractionEventHandler(TriggerClicked);
        //leftControllerEvents.TriggerUnclicked += new ControllerInteractionEventHandler(TriggerUnclicked);
       
        //Add multislider mapping for wavetable.
        WaveTable waves = gameObject.AddComponent<WaveTable>();
        //waves.controllerEvents = rightControllerEvents;
    }

    private void TriggerClicked(object sender)
    {
        //controllerReference = e.controllerReference;
        //var index =  VRTK_ControllerReference.GetRealIndex(e.controllerReference);
        //controllerDevice = VRTK_DeviceFinder.GetControllerByIndex(index, true);
        triggerDown = true;
    }

    private void TriggerUnclicked(object sender)
    {
        triggerDown = false;
        controllerDevice = null;

        List<float> data = new List<float>();
        data.Add(0f);
        data.Add(0f);
        //Send OSC Amplitude to 0 on trigger release.
        OSCHandler.Instance.SendMessageToClient("myClient", "/waveData/" + activeWave, data);
    }

    //Selected from Radial Menu.
    private void SquareWave()
    {
        OSCHandler.Instance.SendMessageToClient("myClient", "/chooseWave", "rect");
        activeMat = squareWave;
        activeWave = "rect";
    }

    private void SawWave()
    {
        OSCHandler.Instance.SendMessageToClient("myClient", "/chooseWave", "saw");
        activeMat = sawWave;
        activeWave = "saw";
    }

    private void TriangleWave()
    {
        OSCHandler.Instance.SendMessageToClient("myClient", "/chooseWave", "tri");
        activeMat = triangleWave;
        activeWave = "tri";
    }

    private void CycleWave()
    {
        OSCHandler.Instance.SendMessageToClient("myClient", "/chooseWave", "cycle");
        activeMat = cycleWave;
        activeWave = "cycle";
    }

    private List<float> ControllerVelocityAndAmplitude()
    {
        List<float> controllerData = new List<float>();
        //float velocity = VRTK_DeviceFinder.GetControllerVelocity(controllerReference).magnitude;
        float height = controllerDevice.transform.position.y;
        height = ModelUtility.Remap(height, 0, 4, 0, 20000);
        //velocity = ModelUtility.Remap(velocity, 0, 5, 0, 1);

        controllerData.Add(height); //Send OSC Amplitude based on velocity. hover at .3
        //controllerData.Add(velocity); //Send OSC Frequency based on y
        return controllerData;
    }


    // Update is called once per frame
    void Update () {

        // Trigger Start
        if (triggerDown) {
            if(numClicks == 0)
            {
                GameObject go = new GameObject();
                go.AddComponent<MeshFilter>();
                go.AddComponent<MeshRenderer>();
                currLine = go.AddComponent<MeshLineRenderer>();
                currLine.lmat = new Material(activeMat);
                currLine.SetWidth(.1f);
            }

            currLine.AddPoint(controllerDevice.transform.position);
            numClicks++;

            List<float> data = ControllerVelocityAndAmplitude();
            currLine.lmat.SetFloat("_SynthFrequency", data[0]);
            OSCHandler.Instance.SendMessageToClient("myClient", "/waveData/" + activeWave, data);
        } 
        else if(!triggerDown)
        {
            numClicks = 0;
            currLine = null;
        }
	}
}
