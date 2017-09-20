using UnityEngine;
using UnityOSC;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnvelopController : MonoBehaviour
{
    EnvelopModel envelopModel;

    // Use this for initialization
    void Start()
    {
        envelopModel = new EnvelopModel();
    }

    // Update is called once per frame
    void Update()
    {
        // Reads all the messages received between the previous update and this one
        for (var i = 0; i < OSCHandler.Instance.packets.Count; i++)
        {
            // Process OSC
            ReceivedOSC(OSCHandler.Instance.packets[i]);
            // Remove them once they have been read.
            OSCHandler.Instance.packets.Remove(OSCHandler.Instance.packets[i]);
            i--;
        }
    }

    // Process OSC message
    private void ReceivedOSC(OSCPacket pckt)
    {
        if (pckt == null) { Debug.Log("Empty packet"); return; }

        char[] delimiterChars = { '/' };

        // Address
        string address = pckt.Address.Substring(1);

        if (address == "bundle")
        { // Position 
            foreach (OSCMessage message in pckt.Data)
            {

                //Debug.Log(message.Address);

                if (message.Address.Substring(1, 6) == "source")
                {
                    String[] packetSplit = message.Address.Split(delimiterChars);
                    int inputNumber = Int32.Parse(packetSplit[2]);

                    //Debug.Log("0::" + message.Data[0]);
                    //Debug.Log("1::" + message.Data[1]);
                    //Debug.Log("2::" + message.Data[2]);

                    float positionX = Midway.cx + float.Parse(message.Data[0].ToString()) * Midway.xRange / 2;
                    float positionY = Midway.cy + float.Parse((string)message.Data[2].ToString()) * Midway.yRange / 2;
                    float positionZ = Midway.cz + float.Parse((string)message.Data[1].ToString()) * -Midway.zRange / 2;

                    envelopModel.decoder.inputs[inputNumber - 1].transform.position = new Vector3(positionX, positionY, positionZ);
                }
            }
        }
        else
        { // Output Levels
            char[] delimiters = { '/' };
            String[] splitAddress = pckt.Address.Split(delimiters);

            if (splitAddress[1] == "envelop")
            {
                int channel = Int32.Parse(splitAddress[3].Substring(2));
                envelopModel.decoder.outputChannels[channel - 1].transform.localScale = new Vector3(100.0f, 100.0f, 100.0f) * (float)pckt.Data[0];
            }

        }

        if (address == "message")
        {
            OSCMessage message = (OSCMessage)pckt.Data[0];
            Debug.Log(message);
        }
    }
}
