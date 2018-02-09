using UnityEngine;
using UnityOSC;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnvelopController : MonoBehaviour
{
    EnvelopModel envelopModel;
    public String OSCReceiveEnvelopData;

    // Use this for initialization
    void Start()
    {
        envelopModel = new EnvelopModel();
    }

    // Process OSC message
    public void EnvelopLevels(string Address, List<object> data)
    {
        Array channelLevels = data.ToArray();
        for(int i = 0; i < data.Count; i++)
        {
            float fnum = (float)(double)data[i];
            envelopModel.decoder.outputChannels[i].transform.localScale = new Vector3(1.25f, 1.25f, 1.25f) * -fnum;
        }
    }

    public void EnvelopSources(string Address, List<object> data)
    {
        char[] delimiterChars = { '/' };
        String[] packetSplit = Address.Split(delimiterChars);
        int inputNumber = Int32.Parse(packetSplit[2]);

        float positionX = envelopModel.decoder.cx + float.Parse(data[0].ToString()) * envelopModel.decoder.xRange / 2;
        float positionY = envelopModel.decoder.cy + float.Parse(data[2].ToString()) * envelopModel.decoder.yRange / 2;
        float positionZ = envelopModel.decoder.cz + float.Parse(data[1].ToString()) * -envelopModel.decoder.zRange / 2;

        envelopModel.decoder.inputs[inputNumber - 1].transform.position = Vector3.Lerp(envelopModel.decoder.inputs[inputNumber - 1].transform.position, new Vector3(positionX, positionY, positionZ), 1f);
    }
}
