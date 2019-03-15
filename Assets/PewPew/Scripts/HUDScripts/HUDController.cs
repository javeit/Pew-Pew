using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace RedTeam.PewPew {

    public class HUDController : GameEventListener {

        const string MusicVolSettingKey = "musicVol";
        const string FXVolSettingKey = "fxVol";
        const string DialogueVolSettingKey = "dialogueVol";

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

        public GameObject[] hearts;
        public GameObject shield;
        public GameObject[] lives;
        public GameObject[] weaponBoxes;
        public GameObject dialogueBox;

        // TODO: Add audio controller to handle music and SFX
        //public AudioSource music;
        //public AudioSource laserShot;
        //public AudioSource gruntShot;
        //public AudioSource missileShot;
        //public AudioSource missileExplode;

        void Update() {

            if (Input.GetKeyDown("escape") || Input.GetKeyDown("joystick button 7"))
                TogglePaused();
        }

        void TogglePaused() {

            if (_paused)
                CurrentEngine.ResumeGame();
            else
                CurrentEngine.PauseGame();
        }

        public void UpdateHeartDisplay(int heartsLeft) {

            for(int i = 0; i < hearts.Length; i++) {

                if (i < heartsLeft)
                    hearts[i].SetActive(true);
                else
                    hearts[i].SetActive(false);
            }
        }

        public void UpdateLivesDisplay(int livesLeft) {

            for(int i = 0; i < lives.Length; i++) {

                if (i < livesLeft)
                    lives[i].SetActive(true);
                else
                    lives[i].SetActive(false);
            }
        }

        public void SetShieldActive(bool shieldUp) {

            shield.SetActive(shieldUp);
        }

        public void SetWeaponActive(int num) {

            for (int i = 0; i < weaponBoxes.Length; i++)
                weaponBoxes[i].SetActive(false);

            if(num >= 0f && num < weaponBoxes.Length)
                weaponBoxes[num].SetActive(true);
        }

        protected override void Awake() {

            EventManager.AddRequest<HUDController>("HUDController", () => this);

            Time.timeScale = 1.0f;

            //music.volume = PlayerPrefs.GetFloat(MusicVolSettingKey) / 6f;
            //laserShot.volume = PlayerPrefs.GetFloat(FXVolSettingKey);
            //gruntShot.volume = 0.5f * PlayerPrefs.GetFloat(FXVolSettingKey);
            //missileShot.volume = PlayerPrefs.GetFloat(FXVolSettingKey);
            //missileExplode.volume = PlayerPrefs.GetFloat(FXVolSettingKey);

            for (int i = 1; i < weaponBoxes.Length; i++)
                weaponBoxes[i].SetActive(false);

            SetWeaponActive(0);

            base.Awake();
        }

        protected override void OnDestroy() {

            EventManager.RemoveRequest<HUDController>("HUDController");

            base.OnDestroy();
        }
    }
}