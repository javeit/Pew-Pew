using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidKillScript : MonoBehaviour {
	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		rb.AddForce(Random.Range (-900.0f, 900.0f), Random.Range (-3900.0f, 900.0f), Random.Range (-900.0f, 900.0f));
		transform.rotation = Random.rotation;
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}
