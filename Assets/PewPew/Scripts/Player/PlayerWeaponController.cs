using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class PlayerWeaponController : MonoBehaviour {

        public LaserScript laser;

        PlayerGunScript gun;
        PlayerMissleScript missile;
        bool OSX;
        bool paused;
        bool playing;

        void Update() {

            if (!playing)
                return;

            if (OSX) {

                if (Input.GetButtonDown("Switch To Gun Mac")) {

                    laser.gameObject.SetActive(false);
                    missile.enabled = false;
                    gun.enabled = true;
                    // TODO: Implement broadcast listener in HUDController
                    EventManager.TriggerBroadcast<int>("SetActiveWeapon", 0);

                } else if (Input.GetButtonDown("Switch To Laser Mac")) {

                    gun.enabled = false;
                    missile.enabled = false;
                    laser.gameObject.SetActive(true);
                    // TODO: Implement broadcast listener in HUDController
                    EventManager.TriggerBroadcast<int>("SetActiveWeapon", 1);

                } else if (Input.GetButtonDown("Switch To Missile Mac")) {

                    laser.gameObject.SetActive(false);
                    gun.enabled = false;
                    missile.enabled = true;
                    // TODO: Implement broadcast listener in HUDController
                    EventManager.TriggerBroadcast<int>("SetActiveWeapon", 2);
                }

            } else {

                if (Input.GetButtonDown("Switch To Gun Windows")) {

                    laser.gameObject.SetActive(false);
                    missile.enabled = false;
                    gun.enabled = true;
                    // TODO: Implement broadcast listener in HUDController
                    EventManager.TriggerBroadcast<int>("SetActiveWeapon", 0);

                } else if (Input.GetButtonDown("Switch To Laser Windows")) {

                    gun.enabled = false;
                    missile.enabled = false;
                    laser.gameObject.SetActive(true);
                    // TODO: Implement broadcast listener in HUDController
                    EventManager.TriggerBroadcast<int>("SetActiveWeapon", 1);

                } else if (Input.GetButtonDown("Switch To Missile Windows")) {

                    laser.gameObject.SetActive(false);
                    gun.enabled = false;
                    missile.enabled = true;
                    // TODO: Implement broadcast listener in HUDController
                    EventManager.TriggerBroadcast<int>("SetActiveWeapon", 2);
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

        void Start() {

            // TODO: Implement broadcast listener in HUDController
            EventManager.TriggerBroadcast<int>("SetActiveWeapon", 0);
        }

        void Awake() {

            if (Application.platform == RuntimePlatform.OSXEditor ||
                Application.platform == RuntimePlatform.OSXPlayer)
                OSX = true;
            else
                OSX = false;

            gun = GetComponentInChildren<PlayerGunScript>();
            missile = GetComponentInChildren<PlayerMissleScript>();

            EventManager.AddBroadcastListener<GameEvent>("GameEvent", OnGameEvent);
        }

        void OnDisable() {

            EventManager.RemoveBroadcastListener<GameEvent>("GameEvent", OnGameEvent);
        }
    }
}