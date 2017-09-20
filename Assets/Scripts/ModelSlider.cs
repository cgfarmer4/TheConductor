using UnityEngine;
using System.Collections;

public class ModelSlider : MonoBehaviour
{
    public void SliderChanged(float sliderValue)
    {
        Debug.Log(sliderValue);

        // 0 to 1 ... scale to 0 - 127
        float sliderData = Remap(sliderValue, 0f, 1f, 0f, 127f);
        OSCHandler.Instance.SendMessageToClient("myClient", "/sliderData", sliderData);
    }
    public static float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
