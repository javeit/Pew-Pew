using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunScript : MonoBehaviour {

	public Transform target;
	public GameObject bulletPrefab;
	public Transform pathObject;
	public float timeBetweenShots;
	public Transform barrel;

	private HUDScript hudScript;
	private float timeToFire;
	private AudioSource shotSound;
	private bool OSX;

	void Start () {
		timeToFire = 0;
		shotSound = this.GetComponent<AudioSource>();
		hudScript = GameObject.Find("CanvasMain").GetComponent<HUDScript>();

		if (Application.platform == RuntimePlatform.OSXEditor ||
			Application.platform == RuntimePlatform.OSXPlayer) {
			OSX = true;
		} else {
			OSX = false;
		}
	}

	void Update () {
		if (!OSX) {
			if ((Input.GetButton ("Fire1") || Input.GetAxis("Fire1 Windows") > 0f)&& hudScript.getPaused () == false) {
				if (timeToFire <= 0) {
					GameObject newBullet = Instantiate (bulletPrefab, pathObject);
					shotSound.Play ();
					newBullet.transform.position = barrel.position;
					newBullet.transform.rotation = Quaternion.LookRotation (transform.forward);
					timeToFire = timeBetweenShots;
				} else {
					timeToFire -= Time.deltaTime;
				}
			} else if (timeToFire > 0) {
				timeToFire = 0;
			}
		} else {
			if ((Input.GetButton ("Fire1") || Input.GetAxis("Fire1 Windows") > 0f) && hudScript.getPaused () == false) {
				if (timeToFire <= 0) {
					GameObject newBullet = Instantiate (bulletPrefab, pathObject);
					shotSound.Play ();
					newBullet.transform.position = barrel.position;
					newBullet.transform.rotation = Quaternion.LookRotation (transform.forward);
					timeToFire = timeBetweenShots;
				} else {
					timeToFire -= Time.deltaTime;
				}
			} else if (timeToFire > 0) {
				timeToFire = 0;
			}
		}
	}
}