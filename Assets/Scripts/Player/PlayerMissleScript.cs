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
	private AudioSource missileSound;
	private bool OSX;

	void Start () {
		hudScript = GameObject.Find("CanvasMain").GetComponent<HUDScript>();
		timeToFire = 0;
		missileSound = GameObject.Find ("MissileLaunchSound").GetComponent<AudioSource> ();

		if (Application.platform == RuntimePlatform.OSXEditor ||
			Application.platform == RuntimePlatform.OSXDashboardPlayer ||
			Application.platform == RuntimePlatform.OSXPlayer) {
			OSX = true;
		} else {
			OSX = false;
		}
	}

	void Update () {
		if (!OSX) {
			if ((Input.GetButtonDown ("Fire1") || Input.GetAxis("Fire1 Windows") > 0f) && hudScript.getPaused () == false) {
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

					missileSound.Play ();
				}
			}
			timeToFire -= Time.deltaTime;
		} else {
			if ((Input.GetButtonDown ("Fire1") || Input.GetAxis("Fire1 Mac") > 0f) && hudScript.getPaused () == false) {
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

					missileSound.Play ();
				}
			}
			timeToFire -= Time.deltaTime;
		}
	}
}