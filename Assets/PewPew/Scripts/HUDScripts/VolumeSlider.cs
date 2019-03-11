using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedTeam.PewPew {

    /// <summary>
    /// A slider which controls the 
    /// </summary>
    public class VolumeSlider : MonoBehaviour {

        public Slider slider;

        public bool active = false;
        float t;

        public void Init(float initialValue, Action<VolumeSlider, float> changeVolume) {

            slider.value = initialValue;

            slider.onValueChanged.AddListener((float value) => changeVolume(this, value));
        }

        void Update() {

            t += Time.deltaTime;

            if (!active)
                return;

            float horizontal = Input.GetAxis("Horizontal");

            if (horizontal <= -1f && t > .3f) {

                slider.value -= 1f;
                t = 0;

            } else if (horizontal >= 1f && t > .3f) {

                slider.value += 1f;
                t = 0;
            }
        }
    }
}