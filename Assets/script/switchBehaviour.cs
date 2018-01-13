using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchBehaviour : interactiveObject {

	public bool flip = false;
	public GameObject destination;
	
	private Animator animator;

	void Start() {
		animator = GetComponent<Animator>();
		base.forgetInit();
	}

	public override void interact() {
		flip = (flip)?false:true;
		Debug.Log("flipped");				// todo : remvoe debug
		if (destination != null) {
			if (flip) destination.GetComponent<switchDestination>().flip(switchDestination.OPEN);
			else destination.GetComponent<switchDestination>().flip(switchDestination.CLOSE);
		}
		animator.SetBool("flip", flip);
	}

	protected override void state0() {
		flip = false;
		animator.SetBool("flip", flip);
		destination.GetComponent<switchDestination>().flip(switchDestination.CLOSE);
	}

	protected override void state1() {

	}

	protected override void state2() {

	}
	
}
