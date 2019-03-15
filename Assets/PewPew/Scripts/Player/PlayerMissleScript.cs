using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class PlayerMissleScript : GameEventListener {

        public Transform target;
        public MissleScript misslePrefab;
        public Transform pathObject;
        public float timeBetweenShots;
        public Transform barrel;
        public AudioSource missileSound;

        float timeToFire;
        GameObject[] targets;
        GameObject missleTarget;
        bool OSX;

        void Update() {

            if (!_playing)
                return;

            if (!OSX) {

                if ((Input.GetButtonDown("Fire1") || Input.GetAxis("Fire1 Windows") > 0f) && !_paused) {

                    if (timeToFire <= 0) {

                        MissleScript newMissle = Instantiate(misslePrefab, pathObject);

                        newMissle.transform.position = barrel.position;
                        newMissle.transform.rotation = Quaternion.LookRotation(transform.forward);

                        if (GameObject.FindWithTag("Enemy") != null) {

                            targets = GameObject.FindGameObjectsWithTag("Enemy");

                            missleTarget = targets[0];

                            for (int i = 0; i < targets.Length; i++) {

                                if ((targets[i].transform.position - target.position).magnitude < (missleTarget.transform.position - target.position).magnitude)
                                    missleTarget = targets[i];
                            }

                            newMissle.target = missleTarget;

                        } else {

                            newMissle.target = null;
                        }

                        timeToFire = timeBetweenShots;

                        missileSound.Play();
                    }
                }

                timeToFire -= Time.deltaTime;

            } else {

                if ((Input.GetButtonDown("Fire1") || Input.GetAxis("Fire1 Mac") > 0f) && !_paused) {

                    if (timeToFire <= 0) {

                        MissleScript newMissle = Instantiate(misslePrefab, pathObject);

                        newMissle.transform.position = barrel.position;
                        newMissle.transform.rotation = Quaternion.LookRotation(transform.forward);

                        if (GameObject.FindWithTag("Enemy") != null) {

                            targets = GameObject.FindGameObjectsWithTag("Enemy");

                            missleTarget = targets[0];

                            for (int i = 0; i < targets.Length; i++) {

                                if ((targets[i].transform.position - target.position).magnitude < (missleTarget.transform.position - target.position).magnitude)
                                    missleTarget = targets[i];
                            }

                            newMissle.target = missleTarget;

                        } else {

                            newMissle.target = null;
                        }

                        timeToFire = timeBetweenShots;

                        missileSound.Play();
                    }
                }

                timeToFire -= Time.deltaTime;
            }
        }

        protected override void Awake() {

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