using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class interactiveObject : MonoBehaviour {

	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "player reach") {
			playerInteractiveField.instance.inReach(this);
		}
	}

	public void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "player reach") {
			playerInteractiveField.instance.inReach(null);
		}
	}

	public abstract void interact();
}
