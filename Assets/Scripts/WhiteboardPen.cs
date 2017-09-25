﻿using UnityEngine;
using System.Collections;
using VRTK;

public class WhiteboardPen : MonoBehaviour
{

    public Whiteboard whiteboard;
    private RaycastHit touch;
    private Quaternion lastAngle;
    private bool lastTouch;

    private VRTK_ControllerReference controllerReference;
    public void GrabObject(Object sender, InteractableObjectEventArgs e)
    {
        VRTK_ControllerEvents events = e.interactingObject.GetComponent<VRTK_ControllerEvents>();
        controllerReference = VRTK_ControllerReference.GetControllerReference(events.gameObject);
        //VRTK_ControllerHaptics.TriggerHapticPulse(controllerReference, 0.05f, 0.1f, 0.05f);
    }

    // Use this for initialization
    void Start()
    {
        // Get our Whiteboard component from the whiteboard object
        this.whiteboard = GameObject.Find("DrawingWall").GetComponent<Whiteboard>();
    }

    // Update is called once per frame
    void Update()
    {
        float tipHeight = transform.Find("Tip").transform.localScale.y;
        Vector3 tip = transform.Find("Tip/TouchPoint").transform.position;

        if (lastTouch)
        {
            tipHeight *= 1.1f;
        }

        // Check for a Raycast from the tip of the pen
        if (Physics.Raycast(tip, transform.up, out touch, tipHeight))
        {
            if (!(touch.collider.tag == "Whiteboard")) return;
            this.whiteboard = touch.collider.GetComponent<Whiteboard>();

            // Give haptic feedback when touching the whiteboard
            //controllerActions.TriggerHapticPulse(0.05f);

            // Set whiteboard parameters
            whiteboard.SetColor(Color.blue);
            whiteboard.SetTouchPosition(touch.textureCoord.x, touch.textureCoord.y);
            whiteboard.ToggleTouch(true);

            // If we started touching, get the current angle of the pen
            if (lastTouch == false)
            {
                lastTouch = true;
                lastAngle = transform.rotation;
            }
        }
        else
        {
            whiteboard.ToggleTouch(false);
            lastTouch = false;
        }

        // Lock the rotation of the pen if "touching"
        if (lastTouch)
        {
            transform.rotation = lastAngle;
        }
    }
}
