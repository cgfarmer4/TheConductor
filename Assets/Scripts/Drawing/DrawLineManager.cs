using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class DrawLineManager : MonoBehaviour {

	public Material lMat;

    //VRTK Controllers
    public VRTK_ControllerEvents leftControllerEvents;
    public VRTK_ControllerEvents rightControllerEvents;
    private GameObject controllerDevice;
    private bool triggerDown;
    private bool triggerStart;

    //private LineRenderer currLine;
    //private GraphicsLineRenderer currLine;
    private LineRenderer currLine;
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
    }

    private void TriggerPressed(object sender, ControllerInteractionEventArgs e)
    {
        triggerDown = true;
        var index = VRTK_ControllerReference.GetRealIndex(e.controllerReference);
        controllerDevice = VRTK_DeviceFinder.GetControllerByIndex(index, true);
    }

    private void TriggerReleased(object sender, ControllerInteractionEventArgs e)
    {
        triggerDown = false;
    }

    // Update is called once per frame
    void Update () {

        // Trigger Start
        if (triggerStart) { 
			GameObject go = new GameObject ();
            currLine = go.AddComponent<LineRenderer>();
            //go.AddComponent<MeshFilter>();
            //go.AddComponent<MeshRenderer>();
            //currLine = go.AddComponent<GraphicsLineRenderer>();
            //currLine.lmat = lMat;

            currLine.startWidth = .1f;
            currLine.endWidth = .1f;

            //currLine.SetWidth(.1f);
            numClicks = 0;
            triggerStart = false;
        }
        // Trigger Hold
        else if (triggerDown) {
            currLine.positionCount = numClicks + 1;
            currLine.SetPosition(numClicks, controllerDevice.transform.position);

            //currLine.AddPoint(controllerDevice.transform.position);
			numClicks++;
		}
	}
}
