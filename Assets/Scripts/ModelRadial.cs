using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

//Attach to RadialKnob prefab.
public class ModelRadial : MonoBehaviour
{
    public VRGameController gameController;
    public Image circleImage;

    // Use this for initialization
    void Awake()
    {
        //Setup controller event listeners
        gameController.TouchpadAxisChanged += TouchpadUpdate;
    }

    void TouchpadUpdate(SteamVR_Controller.Device Controller)
    {
        Vector2 touch = Controller.GetAxis();
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
