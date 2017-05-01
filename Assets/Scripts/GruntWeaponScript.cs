using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntWeaponScript: MonoBehaviour {

	public GameObject weapon;
	public float delayTime;
	public float timeBetweenShots;
	public Transform barrel;

	private Transform target;
	private Transform pathObject;
	private float time;
	private float distanceFromTarget;

	void Start () {
		pathObject = GameObject.FindWithTag ("PathObject").transform;
		target = GameObject.FindWithTag ("GruntTarget").transform;
		time = delayTime;
	}

	void Update () {
		if (time < 0) {
			//if within a reasonable range, fire a bullet
			distanceFromTarget = Vector3.Distance (gameObject.transform.position, target.position);
			if (distanceFromTarget <= 600.0f) {
				GameObject newWeapon = Instantiate (weapon, pathObject);
				newWeapon.transform.position = barrel.position;
				newWeapon.transform.rotation = Quaternion.LookRotation (target.position - barrel.position);
				time = timeBetweenShots;
			}
		}
		time -= Time.deltaTime;
	}
}
