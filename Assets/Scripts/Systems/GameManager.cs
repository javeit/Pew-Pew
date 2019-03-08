using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RedTeam {

    /// <summary>
    /// The GameManager is responsible for initializing certain generic systems and loading the first real scene of the game
    /// </summary>
    public class GameManager : MonoBehaviour {

        public string mainMenuScene;
        public TransitionManager transitionManager;

        IEngine _currentEngine;

        void Awake() {

            EventManager.Init();

            EventManager.AddRequest<GameManager>("GameManager", () => this);
            EventManager.AddRequest<TransitionManager>("TransitionManager", () => transitionManager);
            EventManager.AddRequest<IEngine>("CurrentEngine", () => _currentEngine);

            DontDestroyOnLoad(gameObject);
        }

        void Start() {

            StartCoroutine(transitionManager.Transition(SceneManager.GetActiveScene().name, mainMenuScene));
        }

        void OnDestroy() {

            EventManager.Clean();
        }
    }
}