using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteractiveField : MonoBehaviour {

	private interactiveObject objectInReach;

	public static playerInteractiveField instance;

	// Use this for initialization
	void Start () {
		objectInReach = null;
		instance = this;
	}

	public void inReach(interactiveObject obj) {
		if (objectInReach == obj) objectInReach = null;
		else if (objectInReach == null) {
			objectInReach = obj;
		}
		Debug.Log("got this object " + obj);
	}

	public void interact() {
		if (objectInReach != null) {
			// Debug.Log("intereacting to " + objectInReach);
			objectInReach.interact();
		} else {
			// Debug.Log("it's null JIM!");
		}
	}

}
