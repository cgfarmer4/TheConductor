using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

//Each block in the stepper.

public class ModelStepper : MonoBehaviour
{
    public Text textComponent;
    public int columnStep;
    public int rowPitch;
    private bool selected;
    
    private void Start()
    {
        gameObject.tag = "Step";
    }

    //All events are fired from messages in the manager class.

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

    void BetweenSelect(float touchpadY)
    {
        textComponent.text = "Between Select " + gameObject.name;
        selected = true;

        // -.7 to .7 ... scale to 0 - 127
        float velocity = ModelUtility.Remap(touchpadY, -.7f, .7f, 0f, 127f);

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
        float greenValue = ModelUtility.Remap(velocity, 0f, 127f, 0.5f, 1f);

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
}
