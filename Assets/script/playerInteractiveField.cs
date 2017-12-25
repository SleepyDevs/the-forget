using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteractiveField : MonoBehaviour {

	private GameObject objectInReach;

	// Use this for initialization
	void Start () {
		objectInReach = null;
	}
	
	public void inReach(GameObject obj) {
		objectInReach = obj;
	}
	
	public void interact() {
		if (objectInReach != null) {
			Debug.Log("intereacting to " + objectInReach);
			// objectInReach.interact();
		} else {
			// Debug.Log("it's null JIM!");
		}
	}

}
