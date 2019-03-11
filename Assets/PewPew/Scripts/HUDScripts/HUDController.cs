using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace RedTeam.PewPew {

    public class HUDController : MonoBehaviour {

        const string MusicVolSettingKey = "musicVol";
        const string FXVolSettingKey = "fxVol";
        const string DialogueVolSettingKey = "dialogueVol";

        const string ShipSelectKey = "ShipSelect";

        TransitionManager _transitionManager;

        TransitionManager TransitionManager {
            get {
                if (_transitionManager == null)
                    _transitionManager = EventManager.Request<TransitionManager>("TransitionManager");

                return _transitionManager;
            }
        }

        public string levelSelectScene = "Ship Select";
        public string mainMenuScene = "Main Menu";

        public Button pauseButton;

        public Button[] pauseButtons;

        public GameObject pauseMenu;
        public GameObject[] hearts;
        public GameObject shield;
        public GameObject[] lives;
        public GameObject[] weaponBoxes;
        public GameObject dialogueBox;
        public GameObject selectBox;

        public bool shieldUp = true;

        public AudioSource music;
        public AudioSource laserShot;
        public AudioSource gruntShot;
        public AudioSource missileShot;
        public AudioSource missileExplode;

        public GameObject[] shipModels = new GameObject[3];

        bool paused = false;
        int heartsLeft = 2;
        int livesLeft = 2;

        Vector3 startPosition;

        int index;

        float timeSinceHit;

        void Start() {

            Time.timeScale = 1.0f;

            music.volume = PlayerPrefs.GetFloat(MusicVolSettingKey) / 6f;
            laserShot.volume = PlayerPrefs.GetFloat(FXVolSettingKey);
            gruntShot.volume = 0.5f * PlayerPrefs.GetFloat(FXVolSettingKey);
            missileShot.volume = PlayerPrefs.GetFloat(FXVolSettingKey);
            missileExplode.volume = PlayerPrefs.GetFloat(FXVolSettingKey);

            int shipSelect = PlayerPrefs.GetInt(ShipSelectKey);

            foreach(GameObject ship in shipModels) {

                ship.SetActive(false);
            }

            shipModels[shipSelect].SetActive(true);

            for(int i = 0; i < lives.Length; i++) {

                if (livesLeft < i)
                    lives[i].SetActive(false);
            }

            for (int i = 1; i < weaponBoxes.Length; i++) {
                weaponBoxes[i].SetActive(false);
            }

            pauseButton.onClick.AddListener(TogglePaused);
        }

        void Update() {

            timeSinceHit += Time.deltaTime;

            if (timeSinceHit > 5f && shieldUp == false) {

                shield.SetActive(true);
                shieldUp = true;
            }

            if (Input.GetKeyDown("escape") || Input.GetKeyDown("joystick button 7"))
                TogglePaused();

            if (paused) {

                index = Array.IndexOf(pauseButtons, selectBox.transform.parent.gameObject);

                if (Input.GetKeyDown("down") && index != 2)
                    selectBox.transform.SetParent(pauseButtons[index + 1].transform, false);
                else if (Input.GetKeyDown("up") && index != 0)
                    selectBox.transform.SetParent(pauseButtons[index - 1].transform, false);
                else if (Input.GetKeyDown("return"))
                    pauseButtons[index].GetComponent<Button>().onClick.Invoke();
            }
        }

        public void TogglePaused() {

            if (paused) {

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                pauseMenu.SetActive(false);
                paused = false;
                Time.timeScale = 1.0F;

            } else {

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                pauseMenu.SetActive(true);
                paused = true;
                Time.timeScale = 0.0f;
            }
        }

        public bool GetPaused() {

            return paused;
        }

        public void DecrimentHearts() {

            timeSinceHit = 0f;
            if (shieldUp == true) {
                shield.SetActive(false);
                shieldUp = false;
                return;
            }
            if (heartsLeft >= 0) {
                hearts[heartsLeft].SetActive(false);
                heartsLeft--;
            }
            if (heartsLeft < 0) {

                livesLeft--;
                if (livesLeft < 0) {

                    RestartGame();
                    return;
                }

                heartsLeft = 2;

                StartCoroutine(TransitionManager.Transition(SceneManager.GetActiveScene().name, SceneManager.GetActiveScene().name));
            }
        }

        public void SetWeaponActive(int num) {

            for (int i = 0; i < weaponBoxes.Length; i++) {
                weaponBoxes[i].SetActive(false);
            }

            if(num >= 0f && num < weaponBoxes.Length)
                weaponBoxes[num].SetActive(true);
        }

        public void RestartGame() {

            pauseMenu.SetActive(false);
            paused = false;
            Time.timeScale = 1.0f;
            livesLeft = 2;

            StartCoroutine(TransitionManager.Transition(SceneManager.GetActiveScene().name, levelSelectScene));
        }

        public void QuitGame() {

            StartCoroutine(TransitionManager.Transition(SceneManager.GetActiveScene().name, mainMenuScene));
        }

        public void SetIndex(int i) {

            selectBox.transform.SetParent(pauseButtons[i].transform, false);
            index = i;
        }
    }
}