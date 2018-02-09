using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Attach to Piano keys prefab.

public class ModelPianoKey : MonoBehaviour {
    public int keyNumber;
    public int midiNote;
    public Text textComponent;
    private  SteamVR_Controller.Device controllerReference;
    private float impactMagnifier = 120f;
    private float collisionForce = 0f;
    private float maxCollisionForce = 300f;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.GetComponent<VRGameController>() != null)
        {
            VRGameController gameControllerObject = collider.gameObject.GetComponent<VRGameController>();
            controllerReference = gameControllerObject.Controller;

            collisionForce = controllerReference.velocity.magnitude * impactMagnifier;
            ushort hapticStrength = Convert.ToUInt16(collisionForce / maxCollisionForce);
            gameControllerObject.Vibrate(hapticStrength);
            float collisionMidi = ModelUtility.Remap(collisionForce, 0, 100, 70, 127);

            List<float> pianoData = new List<float>();
            pianoData.Add(midiNote);
            pianoData.Add(collisionMidi);

            OSCHandler.Instance.SendMessageToClient("myClient", "/pianoKey/" + keyNumber, pianoData);
            textComponent.text = "/pianoKey/" + keyNumber + ", " + midiNote + " , " + collisionMidi;
        }        
    }

    private void OnTriggerExit(Collider collider)
    {
        List<float> pianoData = new List<float>();
        pianoData.Add(midiNote);
        pianoData.Add(0);

        OSCHandler.Instance.SendMessageToClient("myClient", "/pianoKey/" + keyNumber, pianoData);
        textComponent.text = "/pianoKey/" + keyNumber + ", " + midiNote + " , " + 0;
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

