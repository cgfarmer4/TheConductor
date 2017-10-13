using UnityEngine;
using System.Collections;

//Attach to Slider callback function for on change.

public class ModelSlider : MonoBehaviour
{
    public void SliderChanged(float sliderValue)
    {
        // 0 to 1 ... scale to 0 - 127
        float sliderData = ModelUtility.Remap(sliderValue, 0f, 1f, 0f, 127f);
        OSCHandler.Instance.SendMessageToClient("myClient", "/sliderData", sliderData);
    }
}
