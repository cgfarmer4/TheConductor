The Conductor 
========================

Toolset for making musical applications with Unity, Max and Ableton.

## Goals
- Create examples for interacting with music and spatial environments.
- Explore patterns and initiate discussion for creating new kinds of musical interactions.
- Provide environments and tools for others to become interested in music creation.

## Components
OSC Address Router, Stepper, Slider, Dial, Position, Waves, Pads, Keys + more.

## Dependencies
[Ableton](https://www.ableton.com/) \
[Max](https://cycling74.com/products/max/) \
[CNMAT-odot](https://github.com/CNMAT/CNMAT-odot) \
[Unity](https://unity3d.com/unity) \
[SteamVR](https://www.assetstore.unity3d.com/en/#!/content/32647)
[OSC package](https://github.com/jorgegarcia/UnityOSC)

Optional:
[Envelop for Live](https://github.com/EnvelopSound/EnvelopForLive)

## Setup

You should already have Ableton and Max installed. All other dependencies are free and open source.

1. Download [o.dot](https://github.com/CNMAT/CNMAT-odot) from Github and place it in your Max packages directory. Typically found in `Documents/Max 7/Packages`. To check, go to Options -> File Preferences in Max.

2. Download and install [Unity](https://unity3d.com/unity).

3. Clone or download the zip of this project and open the folder `TheConductor_Unity` in the Unity Editor.

4. Run the SteamVR scene from the scenes folder. If you have errors, they will be shown in the Unity console. 

5. Open Ableton and add the folder `TheConductor_Max` from this project to your Ableton places in the sidebar. 

6. OSC defaults to running on port 8000 in Unity. You can change the ports and outgoing IP address on the `[OSC]` component in Unity and in each M4L patch.

7. Select the prefab in the Unity scene hierarchy that you would like to use and activate it. 

8. Follow the instructions below for setting up each specific component. 

## Components

### Envelop
**Unity Attach**: empty GameObject \
[Envelop for Live](https://github.com/EnvelopSound/EnvelopForLive) is an open source audio production framework for spatial audio composition and performance. This component contains a spatial audio representation of the decoder for the their speaker installations. You can send positional values and audio levels from Max to Unity for 3d representations. 

### OSC Control
**Unity Attach**: empty GameObject \
Unity script for interacting with any OSC event. When a packet is received with the corresponding name, the callback event is called with a `List<object>` containing the OSC data. 
![alt text](Docs/TC_OSCControl.jpg "OSC Control")

### Midi Receive Events
**Unity Attach**: GameObject \
Receive named midi events in Ableton from Unity collisions. The Midi Send Events script  sends when the GameObject `OnCollisionEnter` event is triggered.
![alt text](Docs/TC_MidiReceive.jpg "Midi Receive")

### Midi Send Events
**Unity Attach**: GameObject or empty GameObject \
Send named midi events to Unity from Ableton. Attach any `public` function to the Note on / off events in the inspector.
![alt text](Docs/TC_MidiSend.jpg "Midi Send")

### VRControllerPosition
**Unity Attach**: VRGameController \
Controller positions to XYZ `live.dial`s. Map the controller positions to any value.
![alt text](Docs/TC_VRControllerPosition.jpg "VR Controller Position")

### VRPosition
**Unity Attach**: GameObject with Transform \
Attach to Unity GameObject and send its transform to XYZ `live.dial`s. Useful for panning Envelop for Live sources.
![alt text](Docs/TC_VRPosition.jpg "VR  Position")

### VRDial
**Unity Attach**: GameObject with UI Canvas child \
Radial UI controller to `live.dial`. This component does not take a name but could be easily modified to do so based on other patterns in these tools.
![alt text](Docs/TC_VRDial.jpg "VR  Dial")

### VRDrumPads
**Unity Attach**: GameObject(s) \
Physics reactive cubes to Ableton drum rack.
![alt text](Docs/TC_VRDrumPad.jpg "VR Drum Pads")

### VRMultiSlider
**Unity Attach**: GameObject(s) \
Interactive cube height transforms to `multislider`. Grab or select cubes with laser pointer. Can select multiple. Scale by amount is mutliplied by the height value. Example of scaling values for other object interpretations.
![alt text](Docs/TC_VRMultislider.jpg "VR Multi Slider")

### VRMidiKeyboard
**Unity Attach**: GameObject \
Virtual piano model sends midi duration and pitch. Represented by `kslider`.
![alt text](Docs/TC_VRMidiKeyboard.jpg "VR  Midi Keyboard")

### VRStepper
**Unity Attach**: GameObject \
Cube represenation of a stepper to `live.step`. Laser pointer controls on / off and touchpad controls velocity.
![alt text](Docs/TC_VRStepper.jpg "VR  Midi Keyboard")

## Deprecated

Why deprecate? VRTK discontinued development and these packages were based heavily on controls available within that sdk. They could easily be revitalized with a little finesse.

### VR2DWave
**Unity Attach**: GameObject \
Draw on 2D material to `waveform~`. 
Deprecation Reason: VRTK made it simple to snap the whiteboard pen to the controller.
![alt text](Docs/TC_VRDrawWave.jpg "VR  Draw Wave")

### VR3DWave
**Unity Attach**: empty GameObject \
New instrument example with a wave picker, controller position and velocity to custom M4L device. 
Deprecation Reason: The dial menu was a VRTK feature. Could easily create new menu and new materials.
![alt text](Docs/TC_VR3dWave.jpg "VR 3d Wave")

### VRSlider
**Unity Attach**: GameObject with UI Canvas child \
UI slider to to `live.slider`.
Deprecation Reason: VRTK made it simple to select Unity UI Canvas in VR. Here are some links to similar implementations.
https://github.com/thestonefox/VRTK/commit/5fa29d7f159b00d9e719455f16d1d4f0bfc6b6b1
https://github.com/Sergey-Shamov/Unity-VR-InputModule/blob/master/VRControllerInputModule.cs
https://ritchielozada.com/2016/01/01/part-8-creating-a-gaze-based-input-module-for-unity/
https://forum.unity.com/threads/using-the-unity-event-system-for-vr.472259/
![alt text](Docs/TC_VRSlider.jpg "VR  Slider")

#### Credits
Many thanks to the work of others whose shoulders I stand on to build musical interfaces.

- [CNMAT](http://cnmat.berkeley.edu/) for providing [o.dot](https://github.com/CNMAT/CNMAT-odot).
- The Envelop team for all the inspiration and help.
- Icons for VR3DWave from the Noun project.
- The band Caspian for the project name. A tribute to their first album.
