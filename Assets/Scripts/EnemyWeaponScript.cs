using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponScript: MonoBehaviour {

	public GameObject weapon;
	public float delayTime;
	public float timeBetweenShots;
	public Transform barrel;

	private Transform pathObject;
	private Transform target;
	private float time;

	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
		pathObject = GameObject.FindWithTag ("PathObject").transform;
		time = delayTime;
	}

	void Update () {
		if (time < 0) {
			GameObject newWeapon = Instantiate (weapon, pathObject);
			newWeapon.transform.position = barrel.position;
			newWeapon.transform.rotation = Quaternion.LookRotation (target.position - barrel.position);
			time = timeBetweenShots;
		}
		time -= Time.deltaTime;
	}
}
