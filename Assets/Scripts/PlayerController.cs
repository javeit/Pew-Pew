using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxSpeed;

	private Rigidbody rigidBody;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
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

	void OnCollisionEnter(Collision col){
		Destroy (gameObject);
	}
}
