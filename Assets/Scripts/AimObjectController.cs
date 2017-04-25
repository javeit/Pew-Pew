using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimObjectController : MonoBehaviour {

	void Start () {
		
	}

	void FixedUpdate () {

		Vector3 temp = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 39));
		transform.position = temp;

		/*if(transform.localPosition.x > 6)
			transform.localPosition = (new Vector3(6f, transform.localPosition.y, transform.localPosition.z));
		else if(transform.localPosition.x < -6)
			transform.localPosition = (new Vector3(-6f, transform.localPosition.y, transform.localPosition.z));

		if(transform.localPosition.y > 3.5)
			transform.localPosition = (new Vector3(transform.localPosition.x, 3.5f, transform.localPosition.z));
		else if(transform.localPosition.y < -3.5)
			transform.localPosition = (new Vector3(transform.localPosition.x, -3.5f, transform.localPosition.z));*/
	}
}
