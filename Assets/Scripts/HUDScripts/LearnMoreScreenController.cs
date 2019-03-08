using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RedTeam.PewPew {

    public class LearnMoreScreenController : MonoBehaviour {

        TransitionManager _transitionManager;

        TransitionManager TransitionManager {
            get {
                if (_transitionManager == null)
                    _transitionManager = EventManager.Request<TransitionManager>("TransitionManager");

                return _transitionManager;
            }
        }

        public string mainMenuScene = "Main Menu";

        void GoBack() {

            StartCoroutine(TransitionManager.Transition(SceneManager.GetActiveScene().name, mainMenuScene));
        }
    }
}