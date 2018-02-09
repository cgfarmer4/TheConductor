using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGameController : MonoBehaviour {

    public delegate void ControllerEvent(SteamVR_Controller.Device controller);
    public event ControllerEvent TouchpadAxisChanged;
    public event ControllerEvent TriggerDown;
    public event ControllerEvent TriggerUp;
    public event ControllerEvent PressDown;
    public event ControllerEvent PressUp;

    private SteamVR_TrackedController trackedObj;
    [HideInInspector]
    public SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.controllerIndex); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedController>();
    }

    public void Vibrate(ushort strength)
    {
        Controller.TriggerHapticPulse(strength);
    }

    // Update is called once per frame
    void Update () {
        // Get the position of the finger
        if (Controller.GetAxis() != Vector2.zero)
        {
            //Debug.Log(gameObject.name + Controller.GetAxis());
            if(TouchpadAxisChanged != null)
                TouchpadAxisChanged(Controller);
        }

        // When you squeeze the hair trigger
        if (Controller.GetHairTriggerDown())
        {
            //Debug.Log(gameObject.name + " Trigger Press");
            if (TriggerDown != null)
                TriggerDown(Controller);
        }

        // When you release the hair trigger
        if (Controller.GetHairTriggerUp())
        {
            //Debug.Log(gameObject.name + " Trigger Release");
            if (TriggerUp != null)
                TriggerUp(Controller);
        }

        // Grip buttons
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            //Debug.Log(gameObject.name + " Grip Press");
            if (PressDown != null)
                PressDown(Controller);
        }

        // Relase grip button
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            //Debug.Log(gameObject.name + " Grip Release");
            if (PressUp != null)
                PressUp(Controller);
        }
    }
}
