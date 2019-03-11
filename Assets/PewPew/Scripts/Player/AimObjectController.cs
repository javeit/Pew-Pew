using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class AimObjectController : MonoBehaviour {

        public float moveSpeedMouse;
        public float moveSpeedController;

        float xValMouse;
        float xValController;
        float yValMouse;
        float yValController;

        bool OSX;
        bool paused;
        bool playing;

        void Update() {

            if (paused)
                return;

            if (!playing)
                return;

            if (OSX) {

                xValMouse = Input.GetAxis("Aim Horizontal Mac");
                yValMouse = Input.GetAxis("Aim Vertical Mac");

                transform.localPosition += new Vector3(xValMouse, yValMouse, 0) * moveSpeedMouse;

                xValController = Input.GetAxis("Aim Horizontal Mac Controller");
                yValController = Input.GetAxis("Aim Vertical Mac Controller");

                transform.localPosition += new Vector3(xValController, yValController, 0) * moveSpeedController;

            } else {

                xValMouse = Input.GetAxis("Aim Horizontal Windows");
                yValMouse = Input.GetAxis("Aim Vertical Windows");

                transform.localPosition += new Vector3(xValMouse, yValMouse, 0) * moveSpeedMouse;

                xValController = Input.GetAxis("Aim Horizontal Windows Controller");
                yValController = Input.GetAxis("Aim Vertical Windows Controller");

                transform.localPosition += new Vector3(xValController, yValController, 0) * moveSpeedController;
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

            if (Application.platform == RuntimePlatform.OSXEditor ||
                Application.platform == RuntimePlatform.OSXPlayer)
                OSX = true;
            else
                OSX = false;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            EventManager.AddBroadcastListener<GameEvent>("GameEvent", OnGameEvent);
        }

        void OnDisable() {

            EventManager.RemoveBroadcastListener<GameEvent>("GameEvent", OnGameEvent);
        }
    }
}