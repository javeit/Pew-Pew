using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

	LineRenderer line;

	void Start () {
		line = GetComponent<LineRenderer> ();
	}

	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			StopCoroutine ("FireLaser");
			StartCoroutine ("FireLaser");
		}
	}

	IEnumerator FireLaser () {
		line.enabled = true;

		while (Input.GetButton("Fire1")) {
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;

			line.SetPosition (0, ray.origin);
			if (Physics.Raycast (ray, out hit, 100)) {
				line.SetPosition (1, hit.point);
				if (hit.rigidbody) {
					if (hit.rigidbody.gameObject.tag == "Enemy") {
						Destroy (hit.rigidbody.gameObject);
					}
				}
			} else {
				line.SetPosition (1, ray.GetPoint (500));
			}

			yield return null;
		}

		line.enabled = false;
	}
}