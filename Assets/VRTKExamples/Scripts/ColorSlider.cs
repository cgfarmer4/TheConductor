using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSlider : MonoBehaviour {

	public float red, green, blue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangedRed(float value) {
		this.red = value;
		SetColor ();
	}

	public void ChangedGreen(float value) {
		this.green = value;
		SetColor ();
	}

	public void ChangedBlue(float value) {
		this.blue = value;
		SetColor ();
	}

	public void SetColor() {
		GetComponent<Renderer>().material.color = new Color(red / 255.0f, green / 255.0f, blue / 255.0f);
	}
}
