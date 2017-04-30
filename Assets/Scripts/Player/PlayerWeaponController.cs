using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

	public LaserScript laser;

	private PlayerGunScript gun;
	private PlayerMissleScript missile;
	private HUDScript hudScript;
	private bool OSX;

	void Start () { 
		if (Application.platform == RuntimePlatform.OSXEditor ||
			Application.platform == RuntimePlatform.OSXDashboardPlayer ||
			Application.platform == RuntimePlatform.OSXPlayer) {
			OSX = true;
		} else {
			OSX = false;
		}
		gun = GetComponent<PlayerGunScript> ();
		missile = GetComponent<PlayerMissleScript> ();
		hudScript = GameObject.Find("CanvasMain").GetComponent<HUDScript>();
		hudScript.setWeaponActive (0);
	}

	void Update () {
		if (OSX) {
			if (Input.GetButtonDown ("Switch To Gun Mac")) {
				laser.gameObject.SetActive (false);
				missile.enabled = false;
				gun.enabled = true;
				hudScript.setWeaponActive (0);
			} else if (Input.GetButtonDown ("Switch To Laser Mac")) {
				gun.enabled = false;
				missile.enabled = false;
				laser.gameObject.SetActive (true);
				hudScript.setWeaponActive (1);
			} else if (Input.GetButtonDown ("Switch To Missile Mac")) {
				laser.gameObject.SetActive (false);
				gun.enabled = false;
				missile.enabled = true;
				hudScript.setWeaponActive (2);
			}
		} else {
			if (Input.GetButtonDown ("Switch To Gun Windows")) {
				laser.gameObject.SetActive (false);
				missile.enabled = false;
				gun.enabled = true;
				hudScript.setWeaponActive (0);
			} else if (Input.GetButtonDown ("Switch To Laser Windows")) {
				gun.enabled = false;
				missile.enabled = false;
				laser.gameObject.SetActive (true);
				hudScript.setWeaponActive (1);
			} else if (Input.GetButtonDown ("Switch To Missile Windows")) {
				laser.gameObject.SetActive (false);
				gun.enabled = false;
				missile.enabled = true;
				hudScript.setWeaponActive (2);
			}
		}
	}
}