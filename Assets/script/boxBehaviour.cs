using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxBehaviour : interactiveObject {

	private playerInteractiveField reachScript;

	private void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "player reach") {
			reachScript = other.gameObject.GetComponent<playerInteractiveField>();
			if (behaviour != null) reachScript.inReach(behaviour);
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "player reach") {
			reachScript = other.gameObject.GetComponent<playerInteractiveField>();
			reachScript.inReach(null);
		}
	}

	// public void intereact();
}
