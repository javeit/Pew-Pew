using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissleScript : MonoBehaviour {

	public Transform target;
	public MissleScript misslePrefab;
	public Transform pathObject;
	public float timeBetweenShots;
	public Transform barrel;

	private HUDScript hudScript;
	private float timeToFire;
	private GameObject[] targets;
	private GameObject missleTarget;

	void Start () {
		hudScript = GameObject.Find("CanvasMain").GetComponent<HUDScript>();
		timeToFire = 0;
	}

	void Update () {
		if (Input.GetButtonDown ("Fire1") && hudScript.getPaused() == false) {
			if (timeToFire <= 0) {

				MissleScript newMissle = Instantiate (misslePrefab, pathObject);

				newMissle.transform.position = barrel.position;
				newMissle.transform.rotation = Quaternion.LookRotation (transform.forward);

				if (GameObject.FindWithTag ("Enemy") != null) {
					
					targets = GameObject.FindGameObjectsWithTag ("Enemy");

					missleTarget = targets [0];
					for (int i = 0; i < targets.Length; i++) {
						if ((targets [i].transform.position - target.position).magnitude < (missleTarget.transform.position - target.position).magnitude) {
							missleTarget = targets [i];
						}
					}
					newMissle.target = missleTarget;
				} else {
					newMissle.target = null;
				}
				timeToFire = timeBetweenShots;
			}
		}
		timeToFire -= Time.deltaTime;
	}
}