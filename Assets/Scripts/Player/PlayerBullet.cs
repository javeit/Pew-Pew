using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet: MonoBehaviour {

	public float moveSpeed;
	public float liveTime;

	void Update () {
		transform.position += transform.forward.normalized * moveSpeed;

		if (liveTime < 0) {
			Destroy ();
		}
		liveTime -= Time.deltaTime;
	}

	void OnTriggerEnter(Collider col){
		if(col.name == "Player" || col.tag == "EnemyBox")
		{
			return;
		}
		Destroy ();
	}

	void Destroy(){
		//Debug.Log ("Setting bullet inactive");
		gameObject.SetActive (false);
	}
}
