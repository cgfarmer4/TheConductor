using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using VRTK;

public class ModelMultiSlider : MonoBehaviour
{
    private GameObject collidingObject;
    private GameObject controllerDevice;
    private bool triggerDown;
    public Text textComponent;
    public int sliderNumber;

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
