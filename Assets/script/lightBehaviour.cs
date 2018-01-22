using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightBehaviour : MonoBehaviour
{

    public KeyCode increaseAlpha;
    public KeyCode decreaseAlpha;
    public float alphaLevel = .1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(increaseAlpha))
        {
            //turn on
            alphaLevel += .1f;
        }

        else if (Input.GetKeyDown(decreaseAlpha))
        {
            //turn off
            alphaLevel -= .1f;
        }

        GetComponent<Renderer>().material.color = new Color(245 / 255f, 255 / 255f, 152 / 255f, alphaLevel);

    }

}
