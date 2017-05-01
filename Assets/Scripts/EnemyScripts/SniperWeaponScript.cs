using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperWeaponScript : MonoBehaviour {

	public LineRenderer lineA;
	public LineRenderer lineB;
	public GameObject lineSource;
	public GameObject lineEnd;
	public float timeBetweenShots;

	private Transform target;
	private float distanceFromTarget;

	public PlayerController hurtthis;

	private float time;


	void Start () {
		target = GameObject.FindWithTag ("GruntTarget").transform;
	}

	void Update () {
		distanceFromTarget = Vector3.Distance (gameObject.transform.position, target.position);
		if (distanceFromTarget <= 800.0f) {
			//constantly update targeting beam
			targetBeam ();

			//activate main beam in intervals
			if (time < 0) {
				StartCoroutine ("FireLaser");
				time = timeBetweenShots;
			}
			time -= Time.deltaTime;
		}
	}

	//generate a line between the snipers cannon and the point its targeting
	//to show players the current place to not be
	void targetBeam () {
		lineA.enabled = true;
		lineA.SetPosition (0, lineSource.transform.position);
		lineA.SetPosition (1, lineEnd.transform.position);
		//always keep main beam position up to date
		lineB.SetPosition (0, lineSource.transform.position);
		lineB.SetPosition (1, lineEnd.transform.position);
	}

	//generate a brighter beam that will ruin players lives if touched
	IEnumerator FireLaser () {
		lineB.enabled = true;

		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 100)) {
			if (hit.rigidbody) {
				if (hit.rigidbody.gameObject.tag == "Player") {
					//CHANGE TO REMOVE HP
					hurtthis.wasHit = true;
				}
			}
			if (hit.collider) {
				if (hit.collider.tag == "Player") {
					//CHANGE TO REMOVE HP
					hurtthis.wasHit = true;
				}
			}
		} else {
		}
			
		//leave beam active for .2secs
		yield return new WaitForSeconds (0.2f);
		lineB.enabled = false;

	}
}
