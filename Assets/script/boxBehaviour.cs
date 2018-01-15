using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxBehaviour : interactiveObject {

	[SerializeField]
	private bool grab = false;

	//########## state variable ###########//
	/*
		state 0 is starting state
		state 1 is pictured state 1
		state 2 is pictured state 2
	 */
	private Vector3[] positionStates;
	private Quaternion[] RotationStates;

	void Start() {
		base.forgetInit();
		positionStates = new Vector3[GameVariable.NumberOfState];
		RotationStates = new Quaternion[GameVariable.NumberOfState];
		positionStates[0] = transform.position;
		RotationStates[0] = transform.rotation;
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
		transform.position = positionStates[1];
		transform.rotation = RotationStates[1];
		if (RB != null) RB.velocity = Vector3.zero;
		grab = false;
	}

	protected override void state2() {

	}

	public override void recordState1() {
		positionStates[1] = transform.position;
		RotationStates[1] = transform.rotation;
	}

	public override void recordState2() {
		
	}
}
