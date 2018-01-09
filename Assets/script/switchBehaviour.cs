using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchBehaviour : interactiveObject {

	public bool flip = false;
	public GameObject destination;
	
	private Animator animator;
	private forgettableObject forgetScript;

	private void Start() {
		animator = GetComponent<Animator>();
		forgetScript = GetComponent<forgettableObject>();
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

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (!forgetScript.isRemembered()) {
			forgetScript.setState(0);
			flip = false;
			animator.SetBool("flip", flip);
			destination.GetComponent<switchDestination>().flip(switchDestination.CLOSE);
		}
	}
	
}
