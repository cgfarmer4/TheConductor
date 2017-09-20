using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelDrumPad : MonoBehaviour
{
    public int padY;
    public int padX; 
    public int midiNote;
    public Text textComponent;

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.tag.Equals("Pad"))
        {
            List<float> padData = new List<float>();
            padData.Add(padY);
            padData.Add(padX);
            padData.Add(midiNote);

            OSCHandler.Instance.SendMessageToClient("myClient", "/drumPad", padData);
            textComponent.text = "/drumPad: " + padData[0] + ", " + padData[1] + ", " +  midiNote;
        }
    }

    void Awake()
    {
        if (!textComponent)
        {
            Debug.LogError("This script needs to be attached to a Text component!");
            enabled = false;
            return;
        }
    }
}