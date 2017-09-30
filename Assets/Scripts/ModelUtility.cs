using UnityEngine;
using System.Collections;

//Utility class for common functions.

public class ModelUtility 
{
    public static float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

}
