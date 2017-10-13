using UnityEngine;
using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityOSC;
using UnityEngine.Events;

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

        // Address
        string address = pckt.Address.Substring(1);
        switch(address)
        {
            case "bundle":
                ParseBundle(pckt.Data);
                break;
        }
    }

    // Class declaration
    [System.Serializable]
    public class OSCEvent : UnityEvent<List<object>> { }

    [Serializable]
    public struct OSCRoute
    {
        public string name;
        public OSCEvent callbackEvent;
    }
    public OSCRoute[] oscRoutes;

    private void ParseBundle(List<object> data)
    {
        foreach (OSCMessage message in data)
        {
            //Check all public values for a match on the address router
            foreach (OSCRoute route in oscRoutes)
            {
                if (route.name == message.Address) // need to run a regex match here.
                {
                    Debug.Log("Found the route yo!");

                    //Each string then has a unity event callback associated with it.
                    route.callbackEvent.Invoke(message.Data);
                    break;
                }
            }
        }
    }

}