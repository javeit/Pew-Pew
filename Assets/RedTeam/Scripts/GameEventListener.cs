using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam {

    public class GameEventListener : MonoBehaviour {

        protected bool _paused;
        protected bool _playing;

        protected virtual void OnInitGame() {}

        protected virtual void OnStartGame() {

            _playing = true;
        }

        protected virtual void OnPauseGame() {

            _paused = true;
        }

        protected virtual void OnResumeGame() {

            _paused = false;
        }

        protected virtual void OnStopGame() {

            _playing = false;
        }

        void OnGameEvent(GameEvent gameEvent) {

            if (gameEvent == GameEvent.InitGame)
                OnInitGame();
            else if (gameEvent == GameEvent.StartGame)
                OnStartGame();
            else if (gameEvent == GameEvent.PauseGame)
                OnPauseGame();
            else if (gameEvent == GameEvent.ResumeGame)
                OnResumeGame();
            else if (gameEvent == GameEvent.StopGame)
                OnStopGame();
        }

        protected virtual void Awake() {

            EventManager.AddBroadcastListener<GameEvent>("GameEvent", OnGameEvent);
        }

        protected virtual void OnDestroy() {

            EventManager.RemoveBroadcastListener<GameEvent>("GameEvent", OnGameEvent);
        }
    }
}
