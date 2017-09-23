using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class ModelDrumPad : MonoBehaviour
{
    public int padY;
    public int padX; 
    public int midiNote;
    public Text textComponent;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private VRTK_ControllerReference controllerReference;
    private float impactMagnifier = 120f;
    private float collisionForce = 0f;
    private float maxCollisionForce = 300f;

    private void Start()
    {
        startRotation = gameObject.transform.rotation;
        startPosition = gameObject.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Reposition());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Pad" && collision.gameObject.GetComponent<VRTK_ControllerEvents>() != null)
        {
            VRTK_ControllerEvents events = collision.gameObject.GetComponent<VRTK_ControllerEvents>();
            controllerReference = VRTK_ControllerReference.GetControllerReference(events.gameObject);

            collisionForce = VRTK_DeviceFinder.GetControllerVelocity(controllerReference).magnitude * impactMagnifier;
            var hapticStrength = collisionForce / maxCollisionForce;
            VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, hapticStrength, 0.1f, 0.05f);
            float collisionMidi = ModelUtility.Remap(collisionForce, 0, 100, 70, 127);

            List<float> padData = new List<float>();
            padData.Add(padY);
            padData.Add(padX);
            padData.Add(midiNote);
            padData.Add(collisionMidi);

            OSCHandler.Instance.SendMessageToClient("myClient", "/drumPad", padData);
            textComponent.text = "/drumPad: " + padData[0] + ", " + padData[1] + ", " + midiNote + " , " + collisionMidi;
        }
        StartCoroutine(Reposition());
    }
    
    IEnumerator Reposition()
    {
        yield return new WaitForSeconds(.1f);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        gameObject.transform.position = startPosition;
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, startRotation, 0.5f);
    }
}