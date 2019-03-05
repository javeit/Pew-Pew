using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

	LineRenderer line;
	//Need this to disable while paused -Scott
	HUDScript hudScript;

	private bool OSX;
	void Start () {
		line = GetComponent<LineRenderer> ();
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
			if (Input.GetButtonDown ("Fire1") || Input.GetAxis("Fire1 Windows") > 0f) {
				StopCoroutine ("FireLaser");
				StartCoroutine ("FireLaser");
			}
		} else {
			if (Input.GetButtonDown ("Fire1") || Input.GetAxis("Fire1 Mac") > 0f) {
				StopCoroutine ("FireLaser");
				StartCoroutine ("FireLaser");
			}
		}
	}

	IEnumerator FireLaser () {
		line.enabled = true;

		while ((Input.GetButtonDown ("Fire1") || (!OSX && Input.GetAxis("Fire1 Windows") > 0f) || (OSX && Input.GetAxis("Fire1 Mac") > 0f)) && !hudScript.getPaused()) {
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
				if (hit.collider) {
					if (hit.collider.tag == "Enemy") {
						Destroy (hit.collider.gameObject);
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