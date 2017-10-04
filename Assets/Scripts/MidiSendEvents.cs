using UnityEngine;
using System.Collections;
using UnityOSC;
using System;
using UnityEngine.Events;
using System.Collections.Generic;

public class MidiSendEvents : MonoBehaviour
{
    public String OSCSendName;
    public float Pitch = 60f;
    public float Velocity = 100f;
    public float Duration = 100f;

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit me!");

        List<object> midiData = new List<object>();
        midiData.Add(Pitch); // Pitch
        midiData.Add(Velocity); // Velocity
        midiData.Add(Duration); // Duration
        midiData.Add(OSCSendName); //Object name

        OSCHandler.Instance.SendMessageToClient("myClient", "/midiNote", midiData);
    }
}
