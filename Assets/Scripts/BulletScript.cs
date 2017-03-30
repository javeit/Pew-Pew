using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public float moveSpeed;
	public float liveTime;

	private Vector3 fireDirection;

	void Start(){
		fireDirection = transform.forward;
		//transform.parent = null;
	}

	void Update () {
		transform.position += fireDirection * moveSpeed * Time.deltaTime;
		if (liveTime < 0) {
			Destroy (gameObject);
		} else {
			liveTime -= Time.deltaTime;
		}
	}
}
