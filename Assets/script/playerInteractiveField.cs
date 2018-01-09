using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteractiveField : MonoBehaviour {

	[SerializeField]
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
		Debug.Log("got this object " + obj);			// todo : remove debug
	}

	public void interact() {
		if (objectInReach != null) {
			// Debug.Log("intereacting to " + objectInReach);
			if (objectInReach.gameObject.tag == "Forgettable Object") {
				if (objectInReach.gameObject.GetComponent<forgettableObject>().isRemembered())
					objectInReach.interact();
			}
			else objectInReach.interact();
		} else {
			// Debug.Log("it's null JIM!");
		}
	}

}
