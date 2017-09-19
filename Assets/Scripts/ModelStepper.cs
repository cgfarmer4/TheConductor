﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using VRTK.UnityEventHelper;
using System;
using VRTK;

public class ModelStepper : MonoBehaviour
{
    public VRTK_DestinationMarker_UnityEvents dmEvents;
    public Text textComponent;
    public int columnStep;
    public int rowPitch;
    private bool selected;
    
    private void Start()
    {
        dmEvents.OnDestinationMarkerEnter.AddListener(MarkerEnter);
        dmEvents.OnDestinationMarkerExit.AddListener(MarkerExit);
        dmEvents.OnDestinationMarkerHover.AddListener(MarkerHover);
        gameObject.tag = "Step";
    }

    private void MarkerEnter(object o, DestinationMarkerEventArgs args)
    {
        //Switch statement based on the touchpad args
        Debug.Log("MARKER ENTER~!" + rowPitch);
    }

    private void MarkerExit(object o, DestinationMarkerEventArgs args)
    {
        Debug.Log("Marker EXIT~!" + rowPitch);
    }

    private void MarkerHover(object o, DestinationMarkerEventArgs args)
    {
        Debug.Log("Marker Hover~!" + rowPitch);
    }


    void Selected()
    {
        textComponent.text = "Select " + gameObject.name;
        selected = true;

        // Data example - 1 62 0 120. 127 127
        List<float> stepperData = new List<float>();
        stepperData.Add(columnStep);
        stepperData.Add(rowPitch);
        stepperData.Add(127f); // velocity
        stepperData.Add(120f); // duration
        stepperData.Add(127f); // extra 1
        stepperData.Add(127f); // extra 2
        ModelStepperManager.Instance.SendMessage("UpdateColumnModel", stepperData);
        OSCHandler.Instance.SendMessageToClient("myClient", "/stepperData", stepperData);
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }

    public static float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    void BetweenSelect(float touchpadY)
    {
        textComponent.text = "Between Select " + gameObject.name;
        selected = true;

        // -.7 to .7 ... scale to 0 - 127
        float velocity = Remap(touchpadY, -.7f, .7f, 0f, 127f);

        // Data example - 1 62 0 120. 127 127
        List<float> stepperData = new List<float>();
        stepperData.Add(columnStep);
        stepperData.Add(rowPitch);
        stepperData.Add(velocity); // velocity
        stepperData.Add(120f); // duration
        stepperData.Add(127f); // extra 1
        stepperData.Add(127f); // extra 2
        ModelStepperManager.Instance.SendMessage("UpdateColumnModel", stepperData);
        OSCHandler.Instance.SendMessageToClient("myClient", "/stepperData", stepperData);

        // 0 - 127 ... scale to 0 - 1
        float greenValue = Remap(velocity, 0f, 127f, 0.5f, 1f);

        Color green = Color.green;
        green.a = greenValue;
        gameObject.GetComponent<Renderer>().material.color = green;
    }

    void Unselected()
    {
        if (selected)
        {
            Debug.Log("Unselect " + gameObject.name);
            textComponent.text = "Unselect " + gameObject.name;
            selected = false;

            List<float> stepperData = new List<float>();
            stepperData.Add(columnStep);
            stepperData.Add(rowPitch);
            stepperData.Add(0f); // velocity
            stepperData.Add(120f); // duration
            stepperData.Add(127f); // extra 1
            stepperData.Add(127f); // extra 2
            OSCHandler.Instance.SendMessageToClient("myClient", "/stepperData", stepperData);

            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    void Update()
    {
    }
}