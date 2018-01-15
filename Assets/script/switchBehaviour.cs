﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchBehaviour : interactiveObject {
	
	public bool flip = false;
	public GameObject destination;
	//########## state variable ###########//
	/*
		state 0 is starting state
		state 1 is pictured state 1
		state 2 is pictured state 2
	 */
	private bool[] flipState;

	
	private Animator animator;

	void Start() {
		animator = GetComponent<Animator>();
		flipState = new bool[GameVariable.NumberOfState];
		flipState[0] = false;
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
		flip = flipState[1];
	}

	protected override void state2() {
		flip = flipState[2];
	}

	public override void recordState1() {
		flipState[1] = flip;
	}

	public override void recordState2() {
		flipState[2] = flip;
	}
	
}
