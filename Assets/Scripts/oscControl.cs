using UnityEngine;
using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityOSC;

public class oscControl : MonoBehaviour
{
    private OSCServer myServer;

    public string outIP = "192.168.0.197";
    public int outPort = 9000;
    public int inPort = 9001;

    // Buffer size of the application (stores 100 messages from different servers)
    public int bufferSize = 100;

    // Script initialization
    void Start()
    {
        // init OSC
        OSCHandler.Instance.Init();

        // Initialize OSC clients (transmitters)
        OSCHandler.Instance.CreateClient("myClient", IPAddress.Parse(outIP), outPort);
        Debug.Log("Created OSC Client:" + outIP + ":" + outPort);

        // Initialize OSC servers (listeners)
        myServer = OSCHandler.Instance.CreateServer("myServer", inPort);

        // Set buffer size (bytes) of the server (default 1024)
        myServer.ReceiveBufferSize = 1024;

        // Set the sleeping time of the thread (default 10)
        myServer.SleepMilliseconds = 10;

    }


    void Update() { }

}