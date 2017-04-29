using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

	public LaserScript laser;

	private PlayerGunScript gun;
	private PlayerMissleScript missle;
	public HUDScript hudScript;

	void Start () { 
		gun = GetComponent<PlayerGunScript> ();
		missle = GetComponent<PlayerMissleScript> ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			laser.gameObject.SetActive (false);
			missle.enabled = false;
			gun.enabled = true;
			hudScript.setWeaponActive (0);
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			gun.enabled = false;
			missle.enabled = false;
			laser.gameObject.SetActive (true);
			hudScript.setWeaponActive (1);
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			laser.gameObject.SetActive (false);
			gun.enabled = false;
			missle.enabled = true;
			hudScript.setWeaponActive (2);
		}
	}
}