using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

	public LaserScript laser;

	private PlayerGunScript gun;

	void Start () {
		gun = GetComponent<PlayerGunScript> ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			laser.gameObject.SetActive (false);
			gun.enabled = true;
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			gun.enabled = false;
			laser.gameObject.SetActive (true);
		}
	}
}