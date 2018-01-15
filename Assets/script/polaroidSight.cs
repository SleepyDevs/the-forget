using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polaroidSight : MonoBehaviour {

	[SerializeField]
	private List<GameObject> objectInSight;
	[SerializeField]
	private List<GameObject>[] picState;
	private Vector3 rayOrigin;
	[SerializeField]
	private GameObject viewPoint;

	// Use this for initialization
	void Start () {
		objectInSight = new List<GameObject>();
		initPic();
		rayOrigin = viewPoint.transform.position;
	}

	private void initPic() {
		
		picState = new List<GameObject>[GameVariable.NumberOfState];
		for (int i = 0; i < GameVariable.NumberOfState; i++) {
			picState[i] = new List<GameObject>();
		}
	}
	
	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Forgettable Object") {
			objectInSight.Add(other.gameObject);
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Forgettable Object") {
			objectInSight.Remove(other.gameObject);
		}
	}

	public void recordState1() {
		picState[1].Clear();
		RaycastHit raycastHit;
		foreach (GameObject gameObj in objectInSight) {
			rayOrigin = viewPoint.transform.position;
			Ray ray = new Ray(rayOrigin, gameObj.transform.position-rayOrigin);
			if (Physics.Raycast(ray, out raycastHit)) {
				if (raycastHit.collider.gameObject == gameObj) {
					gameObj.GetComponent<forgettableObject>().recordState1();
					picState[1].Add(gameObj);
				}
			}
		}
	}

	public void setState1() {
		foreach (GameObject gameObject in picState[1]) {
			gameObject.GetComponent<forgettableObject>().setState(1);
			gameObject.GetComponent<forgettableObject>().remind();
		}
	}

}
