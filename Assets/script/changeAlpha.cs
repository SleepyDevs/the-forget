using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeAlpha : MonoBehaviour {

	public KeyCode increaseAlpha;
	public KeyCode decreaseAlpha;
	public float alphaLevel = .1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown (increaseAlpha)){
			alphaLevel += .9f;}

		else if(Input.GetKeyDown (decreaseAlpha)){
			alphaLevel -= .9f;}
		
		GetComponent<Renderer>().material.color = new Color(245/255f, 255/255f, 152/255f, alphaLevel);

	}

}
