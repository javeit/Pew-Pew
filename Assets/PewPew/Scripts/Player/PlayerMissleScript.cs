using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class PlayerMissleScript : MonoBehaviour {

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
        bool paused;
        bool playing;

        void Update() {

            if (!playing)
                return;

            if (!OSX) {

                if ((Input.GetButtonDown("Fire1") || Input.GetAxis("Fire1 Windows") > 0f) && !paused) {

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

                if ((Input.GetButtonDown("Fire1") || Input.GetAxis("Fire1 Mac") > 0f) && !paused) {

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

        void StartGame() {

            playing = true;
        }

        void StopGame() {

            playing = false;
        }

        void PauseGame() {

            paused = true;
        }

        void ResumeGame() {

            paused = false;
        }

        void OnGameEvent(GameEvent gameEvent) {

            if (gameEvent == GameEvent.StartGame)
                StartGame();
            else if (gameEvent == GameEvent.StopGame)
                StopGame();
            else if (gameEvent == GameEvent.PauseGame)
                PauseGame();
            else if (gameEvent == GameEvent.ResumeGame)
                ResumeGame();
        }

        void Awake() {

            timeToFire = 0;

            if (Application.platform == RuntimePlatform.OSXEditor ||
                Application.platform == RuntimePlatform.OSXPlayer)
                OSX = true;
            else
                OSX = false;

            EventManager.AddBroadcastListener<GameEvent>("GameEvent", OnGameEvent);
        }

        void OnDisable() {

            EventManager.RemoveBroadcastListener<GameEvent>("GameEvent", OnGameEvent);
        }
    }
}