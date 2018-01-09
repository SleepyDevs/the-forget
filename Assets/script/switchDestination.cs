using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class switchDestination : MonoBehaviour {

	public static readonly bool OPEN = true;
	public static readonly bool CLOSE = false;


	public abstract void flip(bool side);

}
