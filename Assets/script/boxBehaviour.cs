﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxBehaviour : interactiveObject {

	public bool grab = false;
	private forgettableObject box;
	private Rigidbody RB;

	private void Start() {
		box = GetComponent<forgettableObject>();
		RB = GetComponent<Rigidbody>();
	}

	public override void interact() {
		if (box.isRemembered()) toogleGrab();
		Debug.Log("box behaviour : intereacting to " + gameObject);
	}

	private void toogleGrab() {
		grab = (grab)?false:true;
	}

	void FixedUpdate() {
		if (Input.GetKeyDown(KeyCode.Return)) {
			// Debug.Log("space");
			Debug.Log("position = " + customCharacterControl.instance.getFaceDirection());
		}
		if (grab) {
			transform.position = customCharacterControl.instance.getPosition() +  3*customCharacterControl.instance.getFaceDirection();
			transform.forward = customCharacterControl.instance.getFaceDirection();
			RB.velocity = Vector3.zero;
		}
		if (!box.isRemembered()) grab = false;
	}
}