using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorBehaviour : switchDestination {

	[SerializeField]
	private bool doorOpen = false;
	private Animator anim;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		anim = GetComponent<Animator>();
	}

	public void openTheDoor() {
		doorOpen = true;
		anim.SetBool("open", true);
	}

	public void closeTheDoor() {
		doorOpen = false;
		anim.SetBool("open", false);
	}

	public override void flip(bool side) {
		if (!side) {
			closeTheDoor();
		}
		else {
			openTheDoor();
		}
	}


	// todo : remove update
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		anim.SetBool("open", doorOpen);
	}


	
}
