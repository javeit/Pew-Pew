using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace RedTeam.PewPew {

    public class PauseMenuController : GameEventListener {

        const string RestartGameConfirmationText = "Are you sure you want to restart?";
        const string QuitGameConfirmationText = "Are you sure you want to quit?";

        IEngine CurrentEngine {
            get {
                return EventManager.Request<IEngine>("CurrentEngine");
            }
        }

        GameController _gameController;

        GameController GameController {
            get {
                if (_gameController == null)
                    _gameController = EventManager.Request<GameController>("GameController");

                return _gameController;
            }
        }

        public GameObject window;
        public Button resumeGameButton;
        public Button restartGameButton;
        public Button quitGameButton;
        public ButtonSelectionController buttonSelect;
        public ConfirmationWindowController confirmationWindow;

        void DisableButtons() {

            resumeGameButton.enabled = false;
            restartGameButton.enabled = false;
            quitGameButton.enabled = false;

            buttonSelect.Disable();
        }

        void EnableButtons() {

            resumeGameButton.enabled = true;
            restartGameButton.enabled = true;
            quitGameButton.enabled = true;

            buttonSelect.Enable();
        }

        void OpenRestartGameConfirmation() {

            DisableButtons();

            confirmationWindow.Show(RestartGameConfirmationText, GameController.RestartGame, EnableButtons);
        }

        void OpenQuitGameConfirmation() {

            DisableButtons();

            confirmationWindow.Show(QuitGameConfirmationText, GameController.QuitGame, EnableButtons);
        }

        void ResumeGame() {

            CurrentEngine.ResumeGame();
        }

        protected override void OnInitGame() {

            base.OnInitGame();

            resumeGameButton.onClick.AddListener(ResumeGame);
            restartGameButton.onClick.AddListener(OpenRestartGameConfirmation);
            quitGameButton.onClick.AddListener(OpenQuitGameConfirmation);

            buttonSelect.Init(new Button[] { resumeGameButton, restartGameButton, quitGameButton });
        }

        protected override void OnPauseGame() {

            base.OnPauseGame();

            window.SetActive(true);
            buttonSelect.Enable();
        }

        protected override void OnResumeGame() {

            base.OnResumeGame();

            window.SetActive(false);
            buttonSelect.Disable();
        }
    }
}