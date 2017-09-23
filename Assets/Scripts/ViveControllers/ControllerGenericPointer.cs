using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
*
* Pre VRTK Controller example for SteamVR.
* 
*/

public class ControllerGenericPointer : MonoBehaviour
{

    private SteamVR_TrackedObject trackedObj;
    public GameObject laserPrefab;
    private GameObject laser;
    private Transform laserTransform;
    private Vector3 hitPoint;
    public LayerMask layerMask;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y,
            hit.distance);
    }

    private void Start()
    {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
    }
    // Check to see if the touchpad is pressed up or down.
    // If it is, send unselected/selected event to appropriate object.
    void Update()
    {
        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            
            RaycastHit hit;

            if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100, layerMask))
            {
                hitPoint = hit.point;
                Vector2 touchpad = (Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));

                if (touchpad.y > 0.7f)
                {
                    if (hit.collider.tag == "Step")
                    {
                        // Max Velocity
                        hit.collider.SendMessage("Selected");
                    }
                }
                else if(touchpad.y > -0.7f && touchpad.y < 0.7f)
                {
                    // Calculate Velocity
                    if (hit.collider.tag == "Step")
                    {
                        hit.collider.SendMessage("BetweenSelect", touchpad.y);
                    }
                }
                else if (touchpad.y < -0.7f)
                {
                    // Min Velocity
                    if (hit.collider.tag == "Step")
                    {
                        hit.collider.SendMessage("Unselected");
                    }
                }

                ShowLaser(hit);
            }
        }
        else
        {
            laser.SetActive(false);
        }
    }
}
