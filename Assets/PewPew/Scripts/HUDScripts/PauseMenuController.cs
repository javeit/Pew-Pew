using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace RedTeam.PewPew {

    public class PauseMenuController : GameEventListener {

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

            confirmationWindow.Show(GameController.RestartGame, EnableButtons);
        }

        void OpenQuitGameConfirmation() {

            DisableButtons();

            confirmationWindow.Show(GameController.QuitGame, EnableButtons);
        }

        void ResumeGame() {

            CurrentEngine.ResumeGame();
        }

        void InitButton(Button button, int selecionIndex, Action onClick) {

            button.onClick.AddListener(() => onClick());

            EventTrigger.Entry pointerEnterEvent = new EventTrigger.Entry();

            pointerEnterEvent.eventID = EventTriggerType.PointerEnter;
            pointerEnterEvent.callback.AddListener((eventData) => buttonSelect.SelectButton(selecionIndex));

            button.GetComponent<EventTrigger>().triggers.Add(pointerEnterEvent);
        }

        protected override void OnInitGame() {

            base.OnInitGame();

            InitButton(resumeGameButton, 0, ResumeGame);
            InitButton(restartGameButton, 1, OpenRestartGameConfirmation);
            InitButton(quitGameButton, 2, OpenQuitGameConfirmation);

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