﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class interactiveObject : forgettableObject {	

	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "player reach") {
			playerInteractiveField.instance.inReach(this);
		}
	}

	public void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "player reach") {
			playerInteractiveField.instance.outReach(this);
		}
	}

	public abstract void interact();
}
