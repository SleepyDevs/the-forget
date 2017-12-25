using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactiveObject : MonoBehaviour {

	private playerInteractiveField reachScript;
	public GameObject behaviour;
 
	// Use this for initialization
	void Start () {
	}
	
	private void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "player reach") {
			reachScript = other.gameObject.GetComponent<playerInteractiveField>();
			// if (behaviour != null) reachScript.inReach(gameObject);
			reachScript.inReach(gameObject);
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "player reach") {
			reachScript = other.gameObject.GetComponent<playerInteractiveField>();
			reachScript.inReach(null);
		}
	}

	// public void intereact() {
	// 	behaviour.intereact();
	// }
}
