using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam {

    /// <summary>
    /// The GameManager is responsible for initializing certain generic systems and loading the first real scene of the game
    /// </summary>
    public class GameManager : MonoBehaviour {

        public string mainMenuScene;
        public TransitionManager transitionManager;

        void OnDestroy() {

            EventManager.Clean();
        }

        void Awake() {

            EventManager.Init();

            EventManager.AddRequest<GameManager>("GameManager", () => this);
            EventManager.AddRequest<TransitionManager>("TransitionManager", () => transitionManager);

            DontDestroyOnLoad(gameObject);
        }

        void Start() {

            StartCoroutine(transitionManager.TransitionTo(mainMenuScene));
        }
    }
}