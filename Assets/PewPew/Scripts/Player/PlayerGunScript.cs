using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class PlayerGunScript : MonoBehaviour {

        public Transform target;
        public GameObject bulletPrefab;
        public Transform pathObject;
        public float timeBetweenShots;
        public Transform barrel;

        float timeToFire;
        AudioSource shotSound;
        bool OSX;

        bool paused;
        bool playing;

        void Update() {

            if (!playing)
                return;

            if (!OSX) {

                if ((Input.GetButton("Fire1") || Input.GetAxis("Fire1 Windows") > 0f) && !paused) {

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

                if ((Input.GetButton("Fire1") || Input.GetAxis("Fire1 Windows") > 0f) && !paused) {

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

            EventManager.AddBroadcastListener<GameEvent>("GameEvent", OnGameEvent);

            shotSound = GetComponent<AudioSource>();

            timeToFire = 0;

            if (Application.platform == RuntimePlatform.OSXEditor ||
                Application.platform == RuntimePlatform.OSXPlayer)
                OSX = true;
            else
                OSX = false;

            paused = false;
        }

        void OnDisable() {
            EventManager.RemoveBroadcastListener<GameEvent>("GameEvent", OnGameEvent);
        }
    }
}