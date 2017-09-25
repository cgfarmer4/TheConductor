using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Backpack : MonoBehaviour {

	[Header("Backpack Options", order = 1)]
	public GameObject spawnObject;
		
	private void OnTriggerStay(Collider collider) {
		VRTK_InteractGrab grabbingObject = (collider.gameObject.GetComponent<VRTK_InteractGrab>() ? collider.gameObject.GetComponent<VRTK_InteractGrab>() : collider.gameObject.GetComponentInParent<VRTK_InteractGrab>());
		if (CanGrab(grabbingObject)) {
			Debug.Log ("Spawning object");

			GameObject spawned = Instantiate(spawnObject);
			grabbingObject.GetComponent<VRTK_InteractTouch>().ForceTouch(spawned);
			grabbingObject.AttemptGrab();
		}
	}

	private bool CanGrab(VRTK_InteractGrab grabbingObject) {
		return (grabbingObject && grabbingObject.GetGrabbedObject() == null && grabbingObject.gameObject.GetComponent<VRTK_ControllerEvents>().grabPressed);
	}
}
