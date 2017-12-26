using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customCharacterControl : MonoBehaviour {

	public static customCharacterControl instance;

	public float speed = 10.0f;
	public float gravity = 2.0f;

	private CharacterController charCon;
	private Vector3 moveDirection;
	private Vector3 faceDirection;
	private float horizontal;
	private float vertical;

	[SerializeField]
	private float fallingSpeed;

	private playerInteractiveField interactiveField;

	// Use this for initialization
	void Start () {
		charCon = GetComponent<CharacterController>();
		interactiveField = GetComponentInChildren<playerInteractiveField>();
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxisRaw("Horizontal");
		vertical = Input.GetAxisRaw("Vertical");

		fallingSpeed += gravity;
		if (charCon.isGrounded) {
			fallingSpeed = 0;
		}
		if (fallingSpeed > 1000) fallingSpeed = 1000;

		moveDirection = new Vector3(horizontal, 0, vertical);
		moveDirection = moveDirection.normalized * speed * Time.deltaTime;
		moveDirection.y -= fallingSpeed * Time.deltaTime;

		charCon.Move(moveDirection);

		if (horizontal != 0 || vertical != 0) {
			faceDirection = Vector3.RotateTowards(transform.forward , new Vector3(vertical, 0, -horizontal), 0.3f, 0.0f);
			transform.forward = (faceDirection);
			Debug.Log(transform.forward);
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			// Debug.Log("space");
			interactiveField.interact();
		}

	}

	public Vector3 getPosition() {
		// Debug.Log("position = " + transform.position);
		return transform.position;
	}

	public Vector3 getFaceDirection() {
		// Debug.Log("forward : " + transform.forward);
		return new Vector3(-transform.forward.z, 0, transform.forward.x);
	}
}
