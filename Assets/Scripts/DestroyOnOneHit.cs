using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnOneHit : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		//Debug.Log ("triggered");
		if (col.gameObject.tag == "Weapon") {
			//Debug.Log ("laser touched");
			Destroy (gameObject);
		}
	}
}