using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunScript : MonoBehaviour {

	public Transform target;
	public Transform pathObject;
	public float timeBetweenShots;
	public Transform barrel;

	HUDScript hudScript;
	float timeToFire;
	AudioSource shotSound;
	bool OSX;
	ObjectPoolerScript bulletPool;

	void Start () {

		bulletPool = GameObject.Find ("ObjectPool").GetComponent<BulletPoolerScript> ();
		timeToFire = 0;
		shotSound = this.GetComponent<AudioSource>();
		hudScript = GameObject.Find("CanvasMain").GetComponent<HUDScript>();

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

			if ((Input.GetButton ("Fire1") || Input.GetAxis("Fire1 Windows") > 0f)&& hudScript.getPaused () == false) {

				if (timeToFire <= 0)
					Fire ();
				else
					timeToFire -= Time.deltaTime;
				
			} else if (timeToFire > 0)
				timeToFire = 0;
			
		} else {
			
			if ((Input.GetButton ("Fire1") || Input.GetAxis("Fire1 Windows") > 0f) && hudScript.getPaused () == false) {

				if (timeToFire <= 0)
					Fire ();
				else
					timeToFire -= Time.deltaTime;
				
			} else if (timeToFire > 0)
				timeToFire = 0;
		}
	}

	void Fire(){
		//new way of getting bullets using pooled list
		GameObject obj = bulletPool.GetPooledObject ();

		if (obj == null)
			return;

		obj.GetComponent<PlayerBullet> ().liveTime = 0.75f;

		obj.transform.parent = pathObject;
		obj.transform.position = barrel.position;
		obj.transform.rotation = Quaternion.LookRotation (transform.forward);
		obj.SetActive (true);

		timeToFire = timeBetweenShots;

//		PlayerBullet newBullet = GetBullet ();
//		shotSound.Play ();
//		newBullet.transform.position = barrel.position;
//		newBullet.transform.rotation = Quaternion.LookRotation (transform.forward);
//		newBullet.gameObject.SetActive (true);
//		timeToFire = timeBetweenShots;
	}
}