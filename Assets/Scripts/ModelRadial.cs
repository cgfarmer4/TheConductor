using UnityEngine;
using System.Collections;
using VRTK;
using UnityEngine.UI;
using System;

public class ModelRadial : MonoBehaviour
{
    public VRTK_ControllerEvents leftControllerEvents;
    public VRTK_ControllerEvents rightControllerEvents;
    public Image circleImage;

    // Use this for initialization
    void Start()
    { 
        //Setup controller event listeners
        leftControllerEvents.TouchpadAxisChanged += new ControllerInteractionEventHandler(TouchpadUpdate);
        rightControllerEvents.TouchpadAxisChanged += new ControllerInteractionEventHandler(TouchpadUpdate);
    }

    void TouchpadUpdate(object sender, ControllerInteractionEventArgs e)
    {
        Vector2 touch = e.touchpadAxis;
        float degrees = FindDegree(touch.x, -touch.y);
        circleImage.fillAmount = degrees / 360f;
        // 0 to 1 ... scale to 0 - 127
        float radialData = ModelUtility.Remap(degrees / 360f, 0f, 1f, 127f, 0f);
        OSCHandler.Instance.SendMessageToClient("myClient", "/radialData", radialData);
    }

    public static float FindDegree(float x, float y)
    {
        float value = (float)((Mathf.Atan2(x, y) / Math.PI) * 180f);
        if (value < 0) value += 360f;

        return value;
    }
}
