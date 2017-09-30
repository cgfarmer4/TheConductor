using UnityEngine;
using System.Collections;
using VRTK;

public class WaveTable : MonoBehaviour
{
    private int numCubes = 513;
    private float waveScale = 0.019f;
    public VRTK_ControllerEvents controllerEvents;

    public void Start()
    {
        //Create all the cubes.
        for (var x = 1; x < numCubes; x++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.parent = gameObject.transform;
            cube.transform.localScale = new Vector3(waveScale, waveScale, waveScale);
            cube.transform.localPosition = new Vector3(waveScale * x, .5f, 0);
            cube.name = "slider" + x;

            cube.AddComponent<VRTK_InteractableObject>();

            ModelMultiSlider slider = cube.AddComponent<ModelMultiSlider>();
            slider.sliderNumber = x;
            slider.scaleByAmount = waveScale;
            slider.oscName = "drawWave";
            slider.controllerEvents = controllerEvents;
        }

    }
}