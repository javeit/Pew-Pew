using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class 
    PlayerAimScript : MonoBehaviour {

        public Transform target;

        bool paused;
        bool playing;

        void Update() {

            if (paused)
                return;

            if (!playing)
                return;

            transform.rotation = Quaternion.LookRotation(target.position - transform.position);
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
        }

        void OnDisable() {

            EventManager.RemoveBroadcastListener<GameEvent>("GameEvent", OnGameEvent);
        }
    }
}