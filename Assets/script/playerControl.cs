using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

	public float speed = 3;
	private Vector3 direction = Vector3.zero;
	private Rigidbody playerRigidbody;
	private Vector3 movement;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		playerRigidbody = GetComponent <Rigidbody>();
	}

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		direction = Vector3.zero;
		direction.z = -Input.GetAxis("Horizontal");
		direction.x = Input.GetAxis("Vertical");
		if (direction != Vector3.zero) 
			transform.forward = direction;

		Move(h, v);
	}

	void Move(float h, float v)
	{
		movement.Set (h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition (transform.position + movement);
	}
}
