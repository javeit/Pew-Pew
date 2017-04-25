using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunScript: MonoBehaviour {

	public Transform target;
	public GameObject bulletPrefab;
	public Transform pathObject;
	public float timeBetweenShots;

	private float timeToFire;

	void Start () {
		timeToFire = 0;
	}

	void Update () {
		if (Input.GetButton ("Fire1")) {
			if (timeToFire <= 0) {
				GameObject newBullet = Instantiate (bulletPrefab, pathObject);
				newBullet.transform.localPosition = transform.parent.localPosition + new Vector3 (0f, 0f, 2.5f);
				newBullet.transform.rotation = Quaternion.LookRotation (transform.forward);
				timeToFire = timeBetweenShots;
			} else {
				timeToFire -= Time.deltaTime;
			}
		} else if(timeToFire > 0){
			timeToFire = 0;
		}
	}
}