using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnOneHit : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag != "EnemyBox"){
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag != "EnemyBox"){
			Destroy (gameObject);
		}
	}
}