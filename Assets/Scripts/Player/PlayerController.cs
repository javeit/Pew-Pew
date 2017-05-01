using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxSpeed;
	public bool wasHit;

	private HUDScript hudScript;
	private Rigidbody rigidBody;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		hudScript = GameObject.Find("CanvasMain").GetComponent<HUDScript>();
	} 
	
	//I added this for testing by triggering wasHit in inspector. Idk if this will 
	//be needed in the end.
	void Update ()
	{
		if (wasHit == true){wasHit = false;Debug.Log ("wasHit");hudScript.decrimentHearts();}
	}

	void FixedUpdate () {
		float verticalMoveSpeed = maxSpeed * Input.GetAxis ("Vertical");
		float horizontalMoveSpeed = maxSpeed * Input.GetAxis ("Horizontal");

		if (((transform.localPosition.x < -3.5) && (horizontalMoveSpeed < 0)) || ((transform.localPosition.x > 3.5) && (horizontalMoveSpeed > 0))) {
			horizontalMoveSpeed = 0;
		}

		if (((transform.localPosition.y < -2) && (verticalMoveSpeed < 0)) || ((transform.localPosition.y > 2) && (verticalMoveSpeed > 0))) {
			verticalMoveSpeed = 0;
		}

		rigidBody.MovePosition (transform.position + (transform.up * verticalMoveSpeed * Time.fixedDeltaTime) + (transform.right * horizontalMoveSpeed * Time.fixedDeltaTime));
	}

	void OnTriggerEnter(Collider col){
		wasHit = true;
	}
}
