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
        if(textCanvas != null)
            textCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (audioPositionElement.transform.hasChanged)
        {
            List<object> positionData = new List<object>();

            positionData.Add(audioPositionElement.transform.position.x);
            positionData.Add(audioPositionElement.transform.position.y);
            positionData.Add(audioPositionElement.transform.position.z);
            positionData.Add(oscOutputName);

            //Send positional data back to Ableton Live  (eap -> envelop audio position)
            OSCHandler.Instance.SendMessageToClient("myClient", "/audioPosition/xyz", positionData);
            if (textCanvas != null)
            {
                textCanvas.SetActive(true);
                canvasState = true;
                textComponent.text = "/audioPosition/xyz\n" + positionData[0] + ", " + positionData[1] + ", " + positionData[2];
            }
           
            audioPositionElement.transform.hasChanged = false;
        }
        else if(canvasState == true)
        {
            textCanvas.SetActive(false);
        }
    }
}
