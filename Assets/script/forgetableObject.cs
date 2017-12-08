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

	public bool reset = false;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Custom/TextureMixShader");
        counter = forgetTime;

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

	
}
