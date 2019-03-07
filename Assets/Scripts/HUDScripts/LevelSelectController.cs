using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class LevelSelectController : MonoBehaviour {

        TransitionManager _transitionManager;

        TransitionManager TransitionManager {
            get {
                if (_transitionManager == null)
                    _transitionManager = EventManager.Request<TransitionManager>("TransitionManager");

                return _transitionManager;
            }
        }

        public LRSelectBoxScript selectScript;
        public GameObject startSelectBox;
        public GameObject backSelectBox;

        public string level1Scene = "Test Scene";
        public string level2Scene = "Level2";
        public string level3Scene = "Level3";

        public string shipSelectScene = "Ship Select";

        bool startSelected = false;

        void StartGame() {

            //PlayerPrefs.SetInt("ShipSelect", selectScript.getIndex());
            if (selectScript.getIndex() == 0)
                StartCoroutine(TransitionManager.TransitionTo(level1Scene));
            else if (selectScript.getIndex() == 1)
                StartCoroutine(TransitionManager.TransitionTo(level2Scene));
            else if (selectScript.getIndex() == 2)
                StartCoroutine(TransitionManager.TransitionTo(level3Scene));
            else
                StartCoroutine(TransitionManager.TransitionTo(level1Scene));
        }

        void GoBack() {

            StartCoroutine(TransitionManager.TransitionTo(shipSelectScene));
        }

        public void StartSelected() {

            startSelectBox.SetActive(true);
            startSelected = true;
        }

        public void StartDeselected() {

            startSelectBox.SetActive(false);
            startSelected = false;
        }

        public void BackSelected() {

            backSelectBox.SetActive(true);
        }

        public void BackDeselected() {

            backSelectBox.SetActive(false);
        }

        void Update() {

            float verticle = Input.GetAxis("Vertical");

            if ((Input.GetKeyDown("down") || verticle <= -1f) && startSelected == false)
                StartSelected();
            else if ((Input.GetKeyDown("up") || verticle >= 1f) && startSelected)
                StartDeselected();
            else if ((Input.GetKeyDown("return") || Input.GetKeyDown("joystick button 0")) && startSelected)
                StartGame();
        }
    }
}