using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (playerSight))]
public class Sight : Editor {


	// ############### FOR DEBUG PURPOSE ################## 
	void OnSceneGUI() {
		playerSight ps = (playerSight) target;
		Handles.color = Color.white;
		// if (ps.rayOrigin != null)
		Handles.DrawWireArc(ps.rayOrigin, Vector3.up, Vector3.forward, 360, .2f);
		if (ps.forgottenObject != null) 
			Handles.DrawWireArc(ps.forgottenObject.transform.position, Vector3.up, Vector3.forward, 360, 0.2f);
		if (ps.forgottenObject != null) 
			Handles.DrawLine(ps.rayOrigin, ps.forgottenObject.transform.position);

		if (ps.hittedObject != null)
			Handles.DrawLine(ps.rayOrigin, ps.hittedObject.transform.position);

		if (ps.inView != null) 
			Handles.DrawLine(ps.rayOrigin, ps.inView.transform.position);
	}
}
