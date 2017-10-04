using UnityEngine;
using System.Collections;

public class Swift : MonoBehaviour
{
    public void TurnColor(float value)
    {
        Color col = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        GetComponent<Renderer>().material.color = col;
    }
}
