using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxBehaviour : interactiveObject {

	[SerializeField]
	private bool grab = false;

	void Start() {
		base.forgetInit();
	}

	public override void interact() {
		// if (box.isRemembered()) toogleGrab();
		toogleGrab();
		Debug.Log("box behaviour : intereacting to " + gameObject); // todo : remove debug
	}

	private void toogleGrab() {
		grab = (grab)?false:true;
	}

	void FixedUpdate() {
		if (grab) {
			transform.position = customCharacterControl.instance.getPosition() +  3*customCharacterControl.instance.getFaceDirection();
			transform.forward = customCharacterControl.instance.getFaceDirection();
			RB.velocity = Vector3.zero;
		}
	}

	protected override void state0() {
		transform.position = positionStates[0];
		transform.rotation = RotationStates[0];
		if (RB != null) RB.velocity = Vector3.zero;
		grab = false;
	}

	protected override void state1() {
		
	}

	protected override void state2() {

	}
}
