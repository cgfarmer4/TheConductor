using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Attach to Controller.
public class ModelControllerPosition : MonoBehaviour
{
    private GameObject controllerDevice;
    public string oscOutputName;

    // Use this for initialization
    void Start()
    {
        if(!GetComponent<SteamVR_TrackedObject>() || !GetComponent<SteamVR_TrackedController>())
        {
            Debug.LogError("Cannot attach controller to object without SteamVR Controller events!");
        }
    }

    //Here we do some modifications to the data in order to make it match up with Envelop which is on a different coordinate system.
    void Update()
    {
        if (gameObject.transform.hasChanged)
        {
            List<object> controllerData = new List<object>();

            // X translates to the Y in Envelop
            // Z is left/right in VR but up/down in Envelop

            controllerData.Add(gameObject.transform.position.x);
            controllerData.Add(gameObject.transform.position.y);
            controllerData.Add(gameObject.transform.position.z);
            controllerData.Add(oscOutputName);

            OSCHandler.Instance.SendMessageToClient("myClient", "/controllerPosition/xyz", controllerData);
            gameObject.transform.hasChanged = false;
        }
    }
}
