using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class MainMenuController : MonoBehaviour {

        public string shipSelectScene = "Ship Select";
        public string learnMoreScene = "Learn More";
        public string aboutScene = "About";
        public string optionsScene = "Options";

        TransitionManager _transitionManager;

        TransitionManager TransitionManager {
            get {
                if (_transitionManager == null)
                    _transitionManager = EventManager.Request<TransitionManager>("TransitionManager");

                return _transitionManager;
            }
        }

        public void StartGame() {
            StartCoroutine(TransitionManager.TransitionTo(shipSelectScene));
        }

        public void LearnMore() {
            StartCoroutine(TransitionManager.TransitionTo(learnMoreScene));
        }

        public void About() {
            StartCoroutine(TransitionManager.TransitionTo(aboutScene));
        }

        public void Options() {
            StartCoroutine(TransitionManager.TransitionTo(optionsScene));
        }
    }
}