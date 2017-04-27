using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

	public LaserScript laser;

	private PlayerGunScript gun;
	public HUDScript hudScript;

	void Start () { 
		gun = GetComponent<PlayerGunScript> ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			laser.gameObject.SetActive (false);
			gun.enabled = true;
			hudScript.setWeaponActive(0);
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			gun.enabled = false;
			laser.gameObject.SetActive (true);
			hudScript.setWeaponActive(1);
		}//when you add missile, please add the function hudScript.setWeaponActive(3);
	}
}