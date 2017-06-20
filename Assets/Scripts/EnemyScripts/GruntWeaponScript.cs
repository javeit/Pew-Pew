using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntWeaponScript: MonoBehaviour {

	public float delayTime;
	public float timeBetweenShots;
	public Transform barrel;

	Transform target;
	Transform pathObject;
	float time;
	float distanceFromTarget;
	AudioSource gruntSound;
	ObjectPoolerScript bulletPool;

	void Start () {
		pathObject = GameObject.FindWithTag ("PathObject").transform;
		target = GameObject.FindWithTag ("GruntTarget").transform;
		time = delayTime;
		gruntSound = GameObject.Find ("GruntSound").GetComponent<AudioSource> ();
		bulletPool = GameObject.Find ("ObjectPool").GetComponent<EnemyBulletPoolerScript> ();
	}

	void Update () {
		if (time < 0) {
			//if within a reasonable range, fire a bullet
			distanceFromTarget = Vector3.Distance (gameObject.transform.position, target.position);
			if (distanceFromTarget <= 600.0f) {

				GameObject newWeapon = bulletPool.GetPooledObject ();
				newWeapon.GetComponent<PlayerBullet> ().liveTime = 5;
				newWeapon.transform.parent = pathObject;
				newWeapon.transform.position = barrel.position;
				newWeapon.transform.rotation = Quaternion.LookRotation (target.position - barrel.position);
				newWeapon.SetActive (true);
				time = timeBetweenShots;
				gruntSound.Play ();
			}
		}
		time -= Time.deltaTime;
	}
}
