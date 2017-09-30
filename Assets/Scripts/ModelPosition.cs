using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Attach to PositionBlock prefab.

public class ModelPosition : MonoBehaviour
{
    GameObject audioPositionElement;
    public string oscOutputName;
    public Text textComponent;
    public GameObject textCanvas;
    bool canvasState;

    // Use this for initialization
    void Start()
    {
        audioPositionElement = gameObject;
        textCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (audioPositionElement.transform.hasChanged)
        {
            List<float> positions = new List<float>();

            positions.Add(audioPositionElement.transform.position.x);
            positions.Add(audioPositionElement.transform.position.y - .6f);
            positions.Add(-audioPositionElement.transform.position.z);

            //Send positional data back to Ableton Live  (eap -> envelop audio position)
            OSCHandler.Instance.SendMessageToClient("myClient", "/audioPosition/" + name + "/xyz", positions);
            textCanvas.SetActive(true);
            canvasState = true;
            textComponent.text = "/audioPosition/" + name + "/xyz\n" + positions[0] + ", " + positions[1] + ", " + positions[2];
            audioPositionElement.transform.hasChanged = false;
        }
        else if(canvasState == true)
        {
            textCanvas.SetActive(false);
        }
    }
}
