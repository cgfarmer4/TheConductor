using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

//Attach to Controller.

public class ModelControllerPosition : MonoBehaviour
{
    private GameObject controllerDevice;
    public string oscOutputName;

    // Use this for initialization
    void Start()
    {
        if(!GetComponent<VRTK_ControllerEvents>())
        {
            Debug.LogError("Cannot attach controller to object without VRTK Controller events!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.hasChanged)
        {
            List<object> controllerData = new List<object>();

            controllerData.Add(gameObject.transform.position.x);
            controllerData.Add(gameObject.transform.position.y);
            controllerData.Add(gameObject.transform.position.z);
            controllerData.Add(oscOutputName);

            OSCHandler.Instance.SendMessageToClient("myClient", "/controllerPosition/xyz", controllerData);
            gameObject.transform.hasChanged = false;
        }
    }
}
