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
            List<float> positions = new List<float>();

            positions.Add(gameObject.transform.position.x);
            positions.Add(gameObject.transform.position.y);
            positions.Add(gameObject.transform.position.z);

            OSCHandler.Instance.SendMessageToClient("myClient", "/controllerPosition/" + oscOutputName + "/xyz", positions);
            gameObject.transform.hasChanged = false;
        }
    }
}
