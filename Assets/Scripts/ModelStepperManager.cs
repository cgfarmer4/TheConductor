using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using VRTK;

//Attach to Collection of stepper rows/columns. Stepper prefab.

public class ModelStepperManager : MonoBehaviour
{
    public VRGameController gameController;
    private static ModelStepperManager m_Instance;
    public static ModelStepperManager Instance { get { return m_Instance; } }
    private bool hovering;
    //Get references to all the rows.]
    public List<GameObject> rows;
    List<List<GameObject>> columns = new List<List<GameObject>>();
    public SteamVR_LaserPointer laserPointer;

    Vector2 touchPadPosition;

    private void Start()
    {
        //Setup controller event listeners
        gameController.TouchpadAxisChanged += TouchpadUpdate;
        laserPointer.PointerIn -= DestinationMarkerEnter;
        laserPointer.PointerIn += DestinationMarkerEnter;
        laserPointer.PointerOut -= DestinationMarkerLeave;
        laserPointer.PointerOut += DestinationMarkerLeave;
    }

    void Awake()
    {
        m_Instance = this;

        //Parse the row data into the individual columns
        for (int x = 0; x < 16; x++)
        {
            columns.Add(new List<GameObject>());

            for (int y = 0; y < 5; y++)
            {
                columns[x].Add(rows[y].transform.GetChild(x).gameObject);
            }
        }
    }

    private void TouchpadUpdate(SteamVR_Controller.Device controller)
    {
        touchPadPosition = controller.GetAxis();
    }

    private void DestinationMarkerEnter(object sender, PointerEventArgs e)
    {
        UpdateStepWithVelocity();
        hovering = true;
    }

    private void DestinationMarkerLeave(object sender, PointerEventArgs e)
    {
        hovering = false;
    }

    private void Update()
    {
        if(hovering)
        {
            UpdateStepWithVelocity();
        }
    }

    private void UpdateStepWithVelocity()
    {
        RaycastHit hit;
        if (Physics.Raycast(laserPointer.transform.position, transform.forward, out hit, 100))
        {
            Debug.Log("updating with velocity " + hit.collider.gameObject.tag);
            Destroy(hit.collider);
            if (hit.collider.tag == "Step")
            {
                if (touchPadPosition.y > 0.7f)
                {
                    // Max Velocity
                    hit.collider.SendMessage("Selected");
                }
                else if (touchPadPosition.y > -0.7f && touchPadPosition.y < 0.7f)
                {
                    // Calculate Velocity
                    hit.collider.SendMessage("BetweenSelect", touchPadPosition.y);
                }
                else if (touchPadPosition.y < -0.7f)
                {
                    // Min Velocity
                    hit.collider.SendMessage("Unselected");
                }
            }
        }            
    }

    void OnDestroy()
    {
        m_Instance = null;
    }

    //Send message to iterate all the objects in each column. Unselect all that should not be active.
    void UpdateColumnModel(List<float> stepperData)
    {
        int columnNumber = (int)stepperData[0] - 1;
        int rowPitch = (int)stepperData[1];

        //Iterate the column game objects turning off all but the active one.
        foreach (GameObject child in columns[columnNumber])
        {
            int childPitch = child.GetComponent<ModelStepper>().rowPitch;
            if (childPitch != rowPitch)
            {
                child.SendMessage("Unselected");
            }
        }
    }
}
