using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissleScript : MonoBehaviour {

	public Transform target;
	public MissleScript misslePrefab;
	public Transform pathObject;
	public float timeBetweenShots;
	public HUDScript hudScript;

	private float timeToFire;
	private GameObject[] targets;
	private GameObject missleTarget;

	void Start () {
		timeToFire = 0;
	}

	void Update () {
		if (Input.GetButton ("Fire1") && hudScript.getPaused() == false) {
			if (timeToFire <= 0) {
				
				if (GameObject.FindWithTag("Enemy") != null) {
					
					targets = GameObject.FindGameObjectsWithTag ("Enemy");
					MissleScript newMissle = Instantiate (misslePrefab, pathObject);

					newMissle.transform.localPosition = transform.parent.localPosition + new Vector3 (0f, 0f, 2.5f);
					newMissle.transform.rotation = Quaternion.LookRotation (transform.forward);

					missleTarget = targets [0];
					for (int i = 0; i < targets.Length; i++) {
						if ((targets [i].transform.position - target.position).magnitude < (missleTarget.transform.position - target.position).magnitude) {
							missleTarget = targets [i];
						}
					}
					newMissle.target = missleTarget;
				}
				timeToFire = timeBetweenShots;
			} else {
				timeToFire -= Time.deltaTime;
			}
		}
	}
}