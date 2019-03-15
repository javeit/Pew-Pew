using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RedTeam.PewPew {

    public class GameController : GameEventListener {

        public string levelSelectScene = "Ship Select";
        public string mainMenuScene = "Main Menu";

        public int HeartsLeft {
            get {
                return _heartsLeft;
            }
            set {
                _heartsLeft = value;
                HUDController.UpdateHeartDisplay(value);
            }
        }

        public int LivesLeft {
            get {
                return _livesLeft;
            }
            set {
                _livesLeft = value;
                HUDController.UpdateLivesDisplay(value);
            }
        }

        public bool ShieldUp {
            get {
                return _shieldUp;
            }
            set {
                _shieldUp = value;
                HUDController.SetShieldActive(value);
            }
        }

        IEngine CurrentEngine {
            get {
                return EventManager.Request<IEngine>("CurrentEngine");
            }
        }

        TransitionManager _transitionManager;

        TransitionManager TransitionManager {
            get {
                if (_transitionManager == null)
                    _transitionManager = EventManager.Request<TransitionManager>("TransitionManager");

                return _transitionManager;
            }
        }

        HUDController _hudController;

        HUDController HUDController {
            get {
                if (_hudController == null)
                    _hudController = EventManager.Request<HUDController>("HUDController");

                return _hudController;
            }
        }

        int _heartsLeft = 2;
        int _livesLeft = 2;
        bool _shieldUp;

        public void LoseHeart() {

            if (ShieldUp) {

                ShieldUp = false;
                return;
            }

            HeartsLeft--;

            if (HeartsLeft < 0) {

                LivesLeft--;

                if (LivesLeft < 0) {

                    EventManager.TriggerBroadcast("RestartGame");
                    return;
                }

                HeartsLeft = 2;

                StartCoroutine(TransitionManager.Transition(SceneManager.GetActiveScene().name, SceneManager.GetActiveScene().name));
            }
        }

        public void RestartGame() {

            if (_paused)
                CurrentEngine.ResumeGame();

            LivesLeft = 2;

            StartCoroutine(TransitionManager.Transition(SceneManager.GetActiveScene().name, levelSelectScene));
        }

        public void QuitGame() {

            StartCoroutine(TransitionManager.Transition(SceneManager.GetActiveScene().name, mainMenuScene));
        }

        protected override void OnStartGame() {

            base.OnStartGame();

            HUDController.UpdateHeartDisplay(HeartsLeft);
            HUDController.UpdateLivesDisplay(LivesLeft);
            HUDController.SetShieldActive(ShieldUp);
        }

        protected override void OnPauseGame() {

            base.OnPauseGame();

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Time.timeScale = 0.0f;
        }

        protected override void OnResumeGame() {

            base.OnResumeGame();

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            Time.timeScale = 1.0f;
        }

        protected override void Awake() {

            EventManager.AddRequest<GameController>("GameController", () => this);
            EventManager.AddBroadcastListener("PlayerHit", LoseHeart);

            base.Awake();
        }

        protected override void OnDestroy() {

            EventManager.RemoveRequest<GameController>("GameController");
            EventManager.RemoveBroadcastListener("PlayerHit", LoseHeart);

            base.OnDestroy();
        }
    }
}