using UnityEngine;
using System.Collections;

public class MidiReceiveExamples : MonoBehaviour
{

    public void receivedMidiOnEvent(float pitch)
    {
        Debug.Log("Midi on event with pitch: " + pitch);
    }

    public void receivedMidiOffEvent(float pitch)
    {
        Debug.Log("Midi off event with pitch: " + pitch);
    }
}
