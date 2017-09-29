using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class DrawLineManager : MonoBehaviour {

	public Material lMat;

    public Material squareWave;
    public Material sawWave;
    public Material cosineWave;
    public Material triangleWave;

    //VRTK Controllers
    public VRTK_ControllerEvents leftControllerEvents;
    public VRTK_ControllerEvents rightControllerEvents;
    private GameObject controllerDevice;
    private bool triggerDown;
    private bool triggerStart;

    private MeshLineRenderer currLine;
    private int numClicks = 0;

    private void Start()
    {
        //Setup controller event listeners
        leftControllerEvents.TriggerPressed += new ControllerInteractionEventHandler(TriggerPressed);
        rightControllerEvents.TriggerPressed += new ControllerInteractionEventHandler(TriggerPressed);

        leftControllerEvents.TriggerTouchStart += new ControllerInteractionEventHandler(TriggerTouchStart);
        rightControllerEvents.TriggerTouchStart += new ControllerInteractionEventHandler(TriggerTouchStart);

        leftControllerEvents.TriggerReleased += new ControllerInteractionEventHandler(TriggerReleased);
        rightControllerEvents.TriggerReleased += new ControllerInteractionEventHandler(TriggerReleased);
    }

    private void TriggerTouchStart(object sender, ControllerInteractionEventArgs e)
    {
        triggerStart = true;
        var index = VRTK_ControllerReference.GetRealIndex(e.controllerReference);
        controllerDevice = VRTK_DeviceFinder.GetControllerByIndex(index, true);
    }

    private void TriggerPressed(object sender, ControllerInteractionEventArgs e)
    {
        triggerDown = true;
    }

    private void TriggerReleased(object sender, ControllerInteractionEventArgs e)
    {
        triggerDown = false;
    }

    //Selected from Radial Menu.
    public void SquareWave()
    {
        OSCHandler.Instance.SendMessageToClient("myClient", "/chooseWave", "rect");
        //Update Mesh Material 
    }

    public void SawWave()
    {
        OSCHandler.Instance.SendMessageToClient("myClient", "/chooseWave", "saw");
        //Update Mesh Material 
    }

    public void TriangleWave()
    {
        OSCHandler.Instance.SendMessageToClient("myClient", "/chooseWave", "tri");
        //Update Mesh Material 
    }

    public void CycleWave()
    {
        OSCHandler.Instance.SendMessageToClient("myClient", "/chooseWave", "cycle");
        //Update Mesh Material 
    }

    // Update is called once per frame
    void Update () {

        // Trigger Start
        if (triggerStart) { 
			GameObject go = new GameObject ();
            go.AddComponent<MeshFilter>();
            go.AddComponent<MeshRenderer>();
            currLine = go.AddComponent<MeshLineRenderer>();
            currLine.lmat = new Material(lMat);

            currLine.SetWidth(.1f);
            triggerStart = false;
        }
        // Trigger Hold
        else if (triggerDown) {
            currLine.AddPoint(controllerDevice.transform.position);
            numClicks++;
		} 
        else if(!triggerDown)
        {
            numClicks = 0;
            currLine = null;
        }
	}
}
