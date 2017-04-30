using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnOneHit : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		//Debug.Log ("triggered");
		if (col.gameObject.tag == "playerGun" || col.gameObject.tag == "playerBeam" || col.gameObject.tag == "playerMissile") {
			//Debug.Log ("enemy hit");
			Destroy (gameObject);
		}
	}
}