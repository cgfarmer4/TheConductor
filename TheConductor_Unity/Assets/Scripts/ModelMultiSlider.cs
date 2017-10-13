using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using VRTK;


//Attach to multislider prefab.


public class ModelMultiSlider : MonoBehaviour
{
    private GameObject collidingObject;
    private GameObject controllerDevice;
    public VRTK_ControllerEvents controllerEvents;
    public string oscName = "multiSlider";
    private bool triggerDown;
    public float scaleByAmount = .25f;
    //public Text textComponent;
    public int sliderNumber;
    private float maxHeight = 3.0f;
    private float minHeight = 0f;

    private void Start()
    {
        if(controllerEvents == null)
        {
            VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
            return;
        }

        //Setup controller event listeners
        controllerEvents.TriggerPressed += new ControllerInteractionEventHandler(TriggerPressed);
        controllerEvents.TriggerReleased += new ControllerInteractionEventHandler(TriggerRelease);
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
        float devicePosition = device.transform.position.y * 1.6f;
        if (devicePosition < maxHeight && devicePosition > minHeight)
        {
            List<float> sliderData = new List<float>();
            gameObject.transform.localScale = new Vector3(scaleByAmount, devicePosition, scaleByAmount);
            //textComponent.text = "/multiSlider : " + sliderNumber + " , " + devicePosition;
            sliderData.Add(sliderNumber);
            sliderData.Add(devicePosition);
            OSCHandler.Instance.SendMessageToClient("myClient", "/" + oscName, sliderData);
        } 
    }

    private void SetCollidingObject(Collider col)
    {
        collidingObject = col.gameObject;
    }

    public void TriggerPressed(object sender, ControllerInteractionEventArgs e)
    {
        var index = VRTK_ControllerReference.GetRealIndex(e.controllerReference);
        controllerDevice = VRTK_DeviceFinder.GetControllerByIndex(index, true);
        triggerDown = true;
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
