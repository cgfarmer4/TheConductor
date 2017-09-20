using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using VRTK;

public class ModelMultiSlider : MonoBehaviour
{
    private GameObject collidingObject;
    private GameObject controllerDevice;
    public VRTK_ControllerEvents leftControllerEvents;
    public VRTK_ControllerEvents rightControllerEvents;
    private bool triggerDown;
    public Text textComponent;
    public int sliderNumber;

    private void Start()
    {
        if(leftControllerEvents == null || rightControllerEvents == null)
        {
            VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
            return;
        }

        //Setup controller event listeners
        leftControllerEvents.TriggerPressed += new ControllerInteractionEventHandler(TriggerPressed);
        leftControllerEvents.TriggerReleased += new ControllerInteractionEventHandler(TriggerRelease);

        rightControllerEvents.TriggerPressed += new ControllerInteractionEventHandler(TriggerPressed);
        rightControllerEvents.TriggerReleased += new ControllerInteractionEventHandler(TriggerRelease);
    }

        void Update()
    {
        if (triggerDown && collidingObject)
        {
            TransformCubeHeight(controllerDevice);
        }

        if (!triggerDown && collidingObject)
        {
            collidingObject = null;
        }
    }

    private void TransformCubeHeight(GameObject device)
    {
        List<float> sliderData = new List<float>();
        float devicePosition = device.transform.position.y * 1.6f;
        gameObject.transform.localScale = new Vector3(.25f, devicePosition, .25f);
        textComponent.text = "/multiSlider : " + sliderNumber + " , " + devicePosition;
        sliderData.Add(sliderNumber);
        sliderData.Add(devicePosition);
        OSCHandler.Instance.SendMessageToClient("myClient", "/multiSlider", sliderData);
    }

    private void SetCollidingObject(Collider col)
    {
        collidingObject = col.gameObject;
    }

    public void TriggerPressed(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("Trigger Pressed!");
        triggerDown = true;
        var index = VRTK_ControllerReference.GetRealIndex(e.controllerReference);
        controllerDevice = VRTK_DeviceFinder.GetControllerByIndex(index, true);
    }

    public void TriggerRelease(object sender, ControllerInteractionEventArgs e)
    {
        triggerDown = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerDown)
        {
            SetCollidingObject(other);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (triggerDown)
        {
            SetCollidingObject(other);
        }
    }
}
