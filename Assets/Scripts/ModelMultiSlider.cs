using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


//Attach to multislider prefab.
public class ModelMultiSlider : MonoBehaviour
{
    public int sliderNumber;
    public float scaleByAmount = .25f;

    private GameObject collidingObject;
    private GameObject controllerDevice;
    public string oscName = "multiSlider";
    private bool triggerDown;
    public Text textComponent;
    private VRGameController gameControllerObject;
    private float maxHeight = 3.0f;
    private float minHeight = 0f;

    void Update()
    {
        if (triggerDown && collidingObject && gameControllerObject)
        {
            TransformCubeHeight(gameControllerObject.gameObject);
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
            textComponent.text = "/multiSlider : " + sliderNumber + " , " + devicePosition;
            sliderData.Add(sliderNumber);
            sliderData.Add(devicePosition);
            OSCHandler.Instance.SendMessageToClient("myClient", "/" + oscName, sliderData);
        }
    }

    private void SetCollidingObject(Collider collider)
    {
        collidingObject = collider.gameObject;
    }

    public void TriggerPressed(SteamVR_Controller.Device sender)
    {
        triggerDown = true;
    }

    public void TriggerRelease(SteamVR_Controller.Device sender)
    {
        triggerDown = false;
    }

    private void AddControllerEvents(VRGameController controller)
    {
        controller.TriggerUp += TriggerPressed;
        controller.TriggerDown += TriggerRelease;
    }

    private void RemoveControllerEvents(VRGameController controller)
    {
        controller.TriggerUp -= TriggerPressed;
        controller.TriggerDown -= TriggerRelease;
        gameControllerObject = null;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.GetComponent<VRGameController>() != null)
        {
            gameControllerObject = collider.gameObject.GetComponent<VRGameController>();
            AddControllerEvents(gameControllerObject);
        }

        if (triggerDown)
        {
            SetCollidingObject(collider);
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (triggerDown)        {
            SetCollidingObject(collider);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        RemoveControllerEvents(gameControllerObject);
    }
}
