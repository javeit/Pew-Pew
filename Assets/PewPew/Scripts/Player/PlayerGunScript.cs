using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class PlayerGunScript : GameEventListener {

        public Transform target;
        public GameObject bulletPrefab;
        public Transform pathObject;
        public float timeBetweenShots;
        public Transform barrel;

        float timeToFire;
        AudioSource shotSound;
        bool OSX;

        void Update() {

            if (!_playing)
                return;

            if (!OSX) {

                if ((Input.GetButton("Fire1") || Input.GetAxis("Fire1 Windows") > 0f) && !_paused) {

                    if (timeToFire <= 0) {

                        GameObject newBullet = Instantiate(bulletPrefab, pathObject);
                        shotSound.Play();
                        newBullet.transform.position = barrel.position;
                        newBullet.transform.rotation = Quaternion.LookRotation(transform.forward);
                        timeToFire = timeBetweenShots;

                    } else {

                        timeToFire -= Time.deltaTime;
                    }

                } else if (timeToFire > 0) {

                    timeToFire = 0;
                }

            } else {

                if ((Input.GetButton("Fire1") || Input.GetAxis("Fire1 Windows") > 0f) && !_paused) {

                    if (timeToFire <= 0) {

                        GameObject newBullet = Instantiate(bulletPrefab, pathObject);
                        shotSound.Play();
                        newBullet.transform.position = barrel.position;
                        newBullet.transform.rotation = Quaternion.LookRotation(transform.forward);
                        timeToFire = timeBetweenShots;

                    } else {

                        timeToFire -= Time.deltaTime;
                    }

                } else if (timeToFire > 0) {

                    timeToFire = 0;
                }
            }
        }

        protected override void Awake() {

            shotSound = GetComponent<AudioSource>();

            timeToFire = 0;

            if (Application.platform == RuntimePlatform.OSXEditor ||
                Application.platform == RuntimePlatform.OSXPlayer)
                OSX = true;
            else
                OSX = false;

            base.Awake();
        }
    }
}