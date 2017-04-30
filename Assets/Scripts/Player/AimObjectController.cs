using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimObjectController : MonoBehaviour {

	public float moveSpeed;

	private float xVal;
	private float yVal;

	void Start(){
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;
	}

	void FixedUpdate () {

		//Vector3 temp = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 40));
		//transform.position = temp;

		xVal = Input.GetAxis ("Aim Horizontal Windows");
		yVal = Input.GetAxis ("Aim Vertical Windows");

		transform.localPosition += new Vector3(xVal, yVal, 0) * moveSpeed;
	}
}
