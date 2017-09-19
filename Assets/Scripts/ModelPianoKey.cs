using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelPianoKey : MonoBehaviour {
    public int keyNumber;
    public int midiNote;

    GameObject pianoKey;
    public Text textComponent;

    private void OnTriggerEnter(Collider collider) {
        if(!collider.gameObject.tag.Equals("Key"))
        {
            OSCHandler.Instance.SendMessageToClient("myClient", "/pianoKey/" + keyNumber, midiNote);
            textComponent.text = "/pianoKey/" + keyNumber;
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