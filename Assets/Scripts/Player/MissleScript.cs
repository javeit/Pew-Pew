using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleScript : MonoBehaviour {

	public float moveSpeed;
	public float aimSpeed;
	public float liveTime;
	public GameObject target;

	private AudioSource explodeSound;

	void Start(){
		explodeSound = GameObject.Find ("MissileExplodeSound").GetComponent<AudioSource> ();
	}

	void Update () {
		if (target != null) {
			transform.position += transform.forward.normalized * moveSpeed;
			transform.rotation = Quaternion.LookRotation (transform.forward + (target.transform.position - transform.position) * aimSpeed);

			if (liveTime < 0) {
				explodeSound.Play ();
				Destroy (gameObject);
			}
			liveTime -= Time.deltaTime;
		} else {
			transform.position += transform.forward;
		}
	}

	void OnCollisionEnter(Collision col){
		//Debug.Log ("hit something");
		explodeSound.Play();
		Destroy (gameObject);
	}
}
