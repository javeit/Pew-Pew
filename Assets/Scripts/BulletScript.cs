using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public float moveSpeed;
	public float liveTime;

	void Start(){
		//GetComponent<Rigidbody> ().velocity = fireDirection * moveSpeed;
		//transform.parent = null;
	}

	void Update () {
		transform.position += transform.forward.normalized * moveSpeed;

		if (liveTime < 0) {
			Destroy (gameObject);
		}
		liveTime -= Time.deltaTime;
	}
		
	void OnCollisionEnter(Collision col){
		Destroy (gameObject);
	}

}
