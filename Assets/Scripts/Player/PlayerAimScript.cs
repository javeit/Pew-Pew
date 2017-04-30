using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimScript : MonoBehaviour {

	public Transform target;
	//Need this to disable while paused -Scott
	HUDScript hudScript;
	void Start()
	{
		hudScript = GameObject.Find("CanvasMain").GetComponent<HUDScript>();
	}

	void Update () {
		if(!hudScript.getPaused())
		{
			transform.rotation = Quaternion.LookRotation (target.position - transform.position);
		}
	}
}