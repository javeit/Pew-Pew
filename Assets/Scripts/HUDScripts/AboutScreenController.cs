using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class AboutScreenController : MonoBehaviour {

        TransitionManager _transitionManager;

        TransitionManager TransitionManager {
            get {
                if (_transitionManager == null)
                    _transitionManager = EventManager.Request<TransitionManager>("TransitionManager");

                return _transitionManager;
            }
        }

        public string mainMenuScene = "Main Menu";

        public void ReturnToMainMenu() {

            StartCoroutine(TransitionManager.TransitionTo(mainMenuScene));
        }
    }
}