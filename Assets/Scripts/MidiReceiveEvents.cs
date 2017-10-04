using UnityEngine;
using System.Collections;
using UnityOSC;
using System;
using UnityEngine.Events;
using System.Collections.Generic;

public class MidiReceiveEvents : MonoBehaviour
{
    // Class declaration
    [System.Serializable]
    public class NoteEvent : UnityEvent<float> { }

    public String OSCReceiveName;
    public NoteEvent NoteOn;
    public NoteEvent NoteOff;

   public void Notes(List<object> data)
    {
        if (data[2].ToString() == OSCReceiveName)
        {
            Debug.Log("I'm an event " + data[2]);

            float pitch = float.Parse(data[0].ToString());
            float velocity = float.Parse(data[1].ToString());

            if (velocity > 0)
            {
                NoteOn.Invoke(pitch);
            }
            else
            {
                NoteOff.Invoke(pitch);
            }
        }
    }
}
