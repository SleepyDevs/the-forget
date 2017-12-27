using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchBehaviour : interactiveObject {

	public bool flip = false;
	
	private Animator animator;

	private void Start() {
		animator = GetComponent<Animator>();
	}

	public override void interact() {
		flip = (flip)?false:true;
		Debug.Log("flipped");
		animator.SetBool("flip", flip);
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		animator.SetBool("flip", flip);
	}
	
}
