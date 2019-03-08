using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RedTeam.PewPew {

    public class CreditsController : MonoBehaviour {

        TransitionManager _transitionManager;

        TransitionManager TransitionManager {
            get {
                if (_transitionManager == null)
                    _transitionManager = EventManager.Request<TransitionManager>("TransitionManager");

                return _transitionManager;
            }
        }

        public ScrollRect creditsScroller;

        public float scrollSpeed;

        public string mainMenuScene = "Main Menu";

        /// <summary>
        /// Scrolls the credits scroller 
        /// </summary>
        public IEnumerator Scroll() {

            Vector2 normalizedScrollPosition = creditsScroller.normalizedPosition;
            normalizedScrollPosition.y = 1f;

            while(creditsScroller.normalizedPosition.y > 0f) {

                yield return null;

                normalizedScrollPosition.y -= scrollSpeed * Time.deltaTime;
            }

            ReturnToMainMenu();
        }

        public void ReturnToMainMenu() {

            StartCoroutine(TransitionManager.Transition(SceneManager.GetActiveScene().name, mainMenuScene));
        }
    }
}