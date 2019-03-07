using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    [RequireComponent(typeof(LineRenderer))]
    public class LaserScript : MonoBehaviour {

        HUDController _hudController;

        HUDController HUDController {
            get {

                if (_hudController == null)
                    _hudController = EventManager.Request<HUDController>("HUDController");

                return _hudController;
            }
        }

        LineRenderer line;
        //Need this to disable while paused -Scott

        bool OSX;

        Coroutine fireLaserCoroutine;

        void Update() {

            if (!HUDController.GetPaused()) {

                if (!OSX) {

                    if (Input.GetButtonDown("Fire1") || Input.GetAxis("Fire1 Windows") > 0f) {

                        if (fireLaserCoroutine != null) {

                            StopCoroutine(fireLaserCoroutine);
                            fireLaserCoroutine = null;
                        }

                        fireLaserCoroutine = StartCoroutine(FireLaser());
                    }

                } else {

                    if (Input.GetButtonDown("Fire1") || Input.GetAxis("Fire1 Mac") > 0f) {

                        if (fireLaserCoroutine != null) {

                            StopCoroutine(fireLaserCoroutine);
                            fireLaserCoroutine = null;
                        }

                        fireLaserCoroutine = StartCoroutine(FireLaser());
                    }
                }
            }
        }

        IEnumerator FireLaser() {

            line.enabled = true;

            while ((Input.GetButtonDown("Fire1") || (!OSX && Input.GetAxis("Fire1 Windows") > 0f) || (OSX && Input.GetAxis("Fire1 Mac") > 0f)) && !HUDController.GetPaused()) {

                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;

                line.SetPosition(0, ray.origin);

                if (Physics.Raycast(ray, out hit, 100)) {

                    line.SetPosition(1, hit.point);

                    if (hit.rigidbody) {

                        if (hit.rigidbody.gameObject.tag == "Enemy")
                            Destroy(hit.rigidbody.gameObject);

                    }

                    if (hit.collider) {

                        if (hit.collider.tag == "Enemy")
                            Destroy(hit.collider.gameObject);
                    }

                } else {

                    line.SetPosition(1, ray.GetPoint(500));
                }

                yield return null;
            }

            line.enabled = false;
        }

        void Start() {

            line = GetComponent<LineRenderer>();

            if (Application.platform == RuntimePlatform.OSXEditor ||
                Application.platform == RuntimePlatform.OSXPlayer)
                OSX = true;
            else
                OSX = false;
        }
    }
}