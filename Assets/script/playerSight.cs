﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSight : MonoBehaviour {


	public GameObject forgottenObject; // todo : remove
    public Vector3 rayOrigin; // todo : move down to local
	public GameObject hittedObject; //todo : remove
	public GameObject viewPoint;
	public GameObject inView; // todo : remove

	private forgettableObject objectScript;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		viewPoint = gameObject.transform.GetChild(0).gameObject;
		rayOrigin = viewPoint.transform.position;
	}

	void OnTriggerStay(Collider other)
	{
        // Destroy(other.gameObject);
		inView = other.gameObject;
		RaycastHit rayHit;
		if (other.gameObject.tag == "Forgettable Object") {
			rayOrigin = viewPoint.transform.position;
			forgottenObject = other.gameObject;
            Ray ray = new Ray(rayOrigin , other.gameObject.transform.position - rayOrigin);
            if (Physics.Raycast(ray, out rayHit))
            {
				hittedObject = rayHit.collider.gameObject;
                if (rayHit.collider.gameObject == other.gameObject)
                {
                    objectScript = other.gameObject.GetComponent<forgettableObject>();
                    if (objectScript != null) 
    			        objectScript.See();
                }
            }
		}
	}

	void OnTriggerExit(Collider other)
	{
        
		// Destroy(other.gameObject);
		 if (other.gameObject.tag == "Forgettable Object") {
            forgottenObject = null;
			objectScript = other.gameObject.GetComponent<forgettableObject>();
               if (objectScript != null) 
                    objectScript.NotSee();
		}
	}
}
