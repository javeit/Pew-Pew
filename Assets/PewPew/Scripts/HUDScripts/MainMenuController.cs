using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RedTeam.PewPew {

    public class MainMenuController : GameEventListener {

        const string QuitGameConfirmationText = "Are you sure you want to quit?";

        PewPewGameConfig _config;

        PewPewGameConfig Config {
            get {
                if (_config == null)
                    _config = (PewPewGameConfig)EventManager.Request<GameConfig>("GameConfig");

                return _config;
            }
        }

        GameManager _gameManager;

        GameManager GameManager {
            get {
                if (_gameManager == null)
                    _gameManager = EventManager.Request<GameManager>("GameManager");

                return _gameManager;
            }
        }

        public ConfirmationWindowController confirmationWindow;
        public ButtonSelectionController buttonSelect;

        public Button startGameButton;
        public Button learnMoreButton;
        public Button optionsButton;
        public Button aboutButton;

        void StartGame() {

            GameManager.SetCurrentEngine(Config.testGameEngineData);
        }
        
        void LearnMore() {
            //StartCoroutine(TransitionManager.Transition(SceneManager.GetActiveScene().name, learnMoreScene));
        }
        
        void About() {
            //StartCoroutine(TransitionManager.Transition(SceneManager.GetActiveScene().name, aboutScene));
        }
        
        void Options() {
            //StartCoroutine(TransitionManager.Transition(SceneManager.GetActiveScene().name, optionsScene));
        }

        void DisableButtons() {

            startGameButton.enabled = false;
            learnMoreButton.enabled = false;
            optionsButton.enabled = false;
            aboutButton.enabled = false;

            buttonSelect.Disable();
        }

        void EnableButtons() {

            startGameButton.enabled = true;
            learnMoreButton.enabled = true;
            optionsButton.enabled = true;
            aboutButton.enabled = true;

            buttonSelect.Enable();
        }

        protected override void OnInitGame() {

            base.OnInitGame();

            DisableButtons();

            startGameButton.onClick.AddListener(StartGame);
            startGameButton.gameObject.SetActive(true);

            learnMoreButton.gameObject.SetActive(false);

            optionsButton.gameObject.SetActive(false);

            aboutButton.gameObject.SetActive(false);

            buttonSelect.Init(new Button[] { startGameButton });

            EnableButtons();
        }
    }
}