using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forgetableObject : MonoBehaviour {

	private Renderer rend;
	public float forgetTime = 10;
	public float rememberTime = 3;
	public bool remembered = false;		//Todo: change back to private
	public float counter = 0;		//todo: change back to private
	public bool seen = false;		//todo: cahnge back to private
	private Vector3[] positionStates;
	private Quaternion[] RotationStates;

	private Rigidbody RB;

	public bool reset = false;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Custom/TextureMixShader");
        counter = forgetTime;
		positionStates = new Vector3[3];
		RotationStates = new Quaternion[3];
		positionStates[0] = transform.position;
		RotationStates[0] = transform.rotation;

		RB = GetComponent<Rigidbody>();
    }

	// Update is called once per frame
	void Update () {
		//float fadeLerp = Mathf.Lerp(0, 1, Mathf.PingPong(Time.time/2, 1));
		//rend.material.SetFloat("_Fade", fadeLerp);
		if (seen) {
			Looking();
		}
		else {
			Forgeting();
		}
		if (reset) counter = 0;
		Fade(1 - counter/forgetTime);
		if (!remembered) setState(0);
		Debug.Log(RB.velocity);
	}

	protected void resetCounter() {
		counter = 0;
	}

	private void Forgeting() {
		if (counter <= 0) {
			remembered = false;
			counter = 0;
		}
		else {
			if (remembered)
				counter -= Time.deltaTime;
			else
				counter -= Time.deltaTime*3;
		}
	}

	private void Looking() {
		if (counter >= forgetTime) {
			remembered = true;
			counter = forgetTime;
		}
		else {
			counter += Time.deltaTime*forgetTime/rememberTime;
		}
	}

	private void Fade(float fadefactor) {
		rend.material.SetFloat("_TexToGray", fadefactor);
	}

	public void See() {
		seen = true;
	}

	public void NotSee() {
		seen = false;
	}

	public void setState(int state) {
		Vector3 Vec0 = new Vector3(0, 0, 0);
		switch(state) {
			case 0 :	transform.position = positionStates[0];
						transform.rotation = RotationStates[0];
						RB.velocity = Vec0;
						break;
			default:	break;
		}
	}
	
}
