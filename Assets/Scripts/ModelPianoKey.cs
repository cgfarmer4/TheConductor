using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

//Attach to Piano prefab.

public class ModelPianoKey : MonoBehaviour {
    public int keyNumber;
    public int midiNote;
    public Text textComponent;
    private VRTK_ControllerReference controllerReference;
    private float impactMagnifier = 120f;
    private float collisionForce = 0f;
    private float maxCollisionForce = 300f;

    private void OnCollisionEnter(Collision collision)
    {
        VRTK_ControllerEvents events = collision.gameObject.GetComponent<VRTK_ControllerEvents>();
        controllerReference = VRTK_ControllerReference.GetControllerReference(events.gameObject);

        collisionForce = VRTK_DeviceFinder.GetControllerVelocity(controllerReference).magnitude * impactMagnifier;
        var hapticStrength = collisionForce / maxCollisionForce;
        VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, hapticStrength, 0.1f, 0.05f);
        float collisionMidi = ModelUtility.Remap(collisionForce, 0, 100, 70, 127);

        List<float> pianoData = new List<float>();
        pianoData.Add(midiNote);
        pianoData.Add(collisionMidi);

        OSCHandler.Instance.SendMessageToClient("myClient", "/pianoKey/" + keyNumber, pianoData);
        textComponent.text = "/pianoKey/" + keyNumber + ", " + midiNote + " , " + collisionMidi;
    }

    private void OnCollisionExit(Collision collision)
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

