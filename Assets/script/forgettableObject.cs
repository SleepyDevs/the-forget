using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class forgettableObject : MonoBehaviour {

	public Renderer[] rend;
	[SerializeField]
	private float forgetTime = 10f;
	[SerializeField]
	private float rememberTime = 3f;
	[SerializeField]
	private bool remembered = false;		//Todo: change back to private
	[SerializeField]
	private float counter = 0f;		//todo: change back to private
	[SerializeField]
	private bool seen = false;		//todo: cahnge back to private

	protected Rigidbody RB;

	public bool reset = false;

	//########## state variable ###########//
	/*
		state 0 is starting state
		state 1 is picture state
		state 2 is ...
	 */
	protected Vector3[] positionStates;
	protected Quaternion[] RotationStates;

    // Use this for initialization
    protected void forgetInit()
    {
		rend = new Renderer[1];
        rend[0] = GetComponent<Renderer>();
		if (rend[0] == null) {
			rend = new Renderer[transform.childCount];
			// rend = GetComponentInChildren<Renderer>();		
			for (int nchild = 0 ; nchild < transform.childCount; nchild++) {
				rend[nchild] = transform.GetChild(nchild).GetComponent<Renderer>();
			}
		}
        // rend.material.shader = Shader.Find("Custom/TextureMixShader");
        counter = forgetTime;
		positionStates = new Vector3[3];
		RotationStates = new Quaternion[3];
		positionStates[0] = transform.position;
		RotationStates[0] = transform.rotation;

		RB = GetComponent<Rigidbody>();
		if (RB == null) {
			RB = GetComponentInChildren<Rigidbody>();
		}
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
		if (!isRemembered()) setState(0);
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
		if (rend == null) Debug.Log("IT'S NULL, JIM!"); 
		foreach (Renderer rdd in rend) {
			rdd.material.SetFloat("_TexToGray", fadefactor);
		}
		// rend.material.SetFloat("_TexToGray", fadefactor);
		
	}

	public void See() {
		seen = true;
	}

	public void NotSee() {
		seen = false;
	}

	public void setState(int state) {
		switch(state) {
			// case 0 :	transform.position = positionStates[0];
						// transform.rotation = RotationStates[0];
						// if (RB != null) RB.velocity = Vector3.zero;
			case 0 :	state0(); break;
			case 1 : 	state1(); break;
			case 2 : 	state2(); break;
			default:	break;
		}
	}

	public bool isRemembered() { 
		return remembered;
	}

	protected abstract void state0();
	protected abstract void state1();
	protected abstract void state2();
}
