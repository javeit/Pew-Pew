using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class OptionsController : MonoBehaviour {

        const string MusicVolSettingKey = "musicVol";
        const string FXVolSettingKey = "fxVol";
        const string DialogueVolSettingKey = "dialogueVol";

        TransitionManager _transitionManager;

        TransitionManager TransitionManager {
            get {
                if (_transitionManager == null)
                    _transitionManager = EventManager.Request<TransitionManager>("TransitionManager");

                return _transitionManager;
            }
        }

        public VolumeSlider musicSlider;
        public VolumeSlider fxSlider;
        public VolumeSlider dialogueSlider;

        public AudioSource musicSource;
        public AudioSource fxSource;
        public AudioSource dialogueSource;

        public string mainMenuScene = "Main Menu";

        VolumeSlider activeSlider;
        public GameObject selectBox;
        float t;

        public void SetActiveSlider(VolumeSlider s) {

            activeSlider.active = false;

            activeSlider = s;
            activeSlider.active = true;

            selectBox.transform.SetParent(s.transform, false);
        }

        public void GoBack() {

           StartCoroutine(TransitionManager.TransitionTo(mainMenuScene));
        }

        void ChangeVolume(VolumeSlider slider, float value) {

            string settingName = string.Empty;
            AudioSource audioSource = null;

            if (slider == musicSlider) {

                settingName = MusicVolSettingKey;
                audioSource = musicSource;

            } else if (slider == fxSlider) {

                settingName = FXVolSettingKey;
                audioSource = fxSource;
                
            } else if (slider == dialogueSlider) {

                settingName = DialogueVolSettingKey;
                audioSource = dialogueSource;
            }

            if (audioSource != null && !string.IsNullOrEmpty(settingName)) {

                PlayerPrefs.SetFloat(settingName, value / 20f);

                audioSource.Stop();
                audioSource.volume = value / 20;
                audioSource.Play();

                PlayerPrefs.Save();
            }
        }

        void Update() {

            t += Time.deltaTime;

            float horizontalMove = Input.GetAxis("Vertical");

            if ((Input.GetKeyDown("down") || horizontalMove <= -1f) && t > .3f) {

                if (activeSlider != dialogueSlider) {

                    if (activeSlider == musicSlider)
                        SetActiveSlider(fxSlider);
                    else if (activeSlider == fxSlider)
                        SetActiveSlider(dialogueSlider);
                }

                t = 0;

            } else if ((Input.GetKeyDown("up") || horizontalMove >= 1f) && t > .3f) {

                if (activeSlider != musicSlider) {

                    if (activeSlider == fxSlider)
                        SetActiveSlider(musicSlider);
                    else if (activeSlider == dialogueSlider)
                        SetActiveSlider(fxSlider);
                }

                t = 0;
            }
        }

        void Start() {

            SetActiveSlider(musicSlider);
        }

        void Awake() {

            musicSlider.Init(PlayerPrefs.GetFloat(MusicVolSettingKey) * 20f, ChangeVolume);
            fxSlider.Init(PlayerPrefs.GetFloat(FXVolSettingKey) * 20f, ChangeVolume);
            dialogueSlider.Init(PlayerPrefs.GetFloat(DialogueVolSettingKey) * 20f, ChangeVolume);
        }
    }
}