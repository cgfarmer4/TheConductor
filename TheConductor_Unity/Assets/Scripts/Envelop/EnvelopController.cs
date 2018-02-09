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

    // Process OSC message
    public void EnvelopPosition(List<object> data)
    {
        char[] delimiterChars = { '/' };

        // Address        
        string address = data[2].ToString();

        if (address == "bundle")
        { // Position 
            Debug.Log("heard Envelop position" + data);
            //foreach (OSCMessage message in pckt.Data)
            //{
            //    if (message.Address.Length > 5 && message.Address.Substring(1, 6) == "source")
            //    {
            //        String[] packetSplit = message.Address.Split(delimiterChars);
            //        int inputNumber = Int32.Parse(packetSplit[2]);

            //        float positionX = Midway.cx + float.Parse(message.Data[0].ToString()) * Midway.xRange / 2;
            //        float positionY = Midway.cy + float.Parse((string)message.Data[2].ToString()) * Midway.yRange / 2;
            //        float positionZ = Midway.cz + float.Parse((string)message.Data[1].ToString()) * -Midway.zRange / 2;

            //        envelopModel.decoder.inputs[inputNumber - 1].transform.position = new Vector3(positionX, positionY, positionZ);
            //    }
            //}
        }
    }

    public void EnvelopLevels(List<object> data)
    {
        char[] delimiters = { '/' };
        String[] splitAddress = data[2].ToString().Split(delimiters);

        if (splitAddress[1] == "envelop")
        {
            Debug.Log("heard Envelop level" + data);
            //int channel = Int32.Parse(splitAddress[3].Substring(2));
            //envelopModel.decoder.outputChannels[channel - 1].transform.localScale = new Vector3(100.0f, 100.0f, 100.0f) * (float)pckt.Data[0];
        }
    }
}
