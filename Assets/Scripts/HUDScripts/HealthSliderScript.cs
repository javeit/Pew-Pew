using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedTeam.PewPew {

    public class HealthSliderScript : MonoBehaviour {

        public Slider healthSlider;
        CoreColor corScript;
        CreditsController credits;
        bool calledCredits = false;
        //public int health;

        
        void Update() {

            healthSlider.value = corScript.coreHP;

            if (!calledCredits && corScript.coreHP <= 0) {

                StartCoroutine(credits.Scroll());
                calledCredits = true;
            }
        }

        void Awake() {

            corScript = GameObject.Find("CapitalCore").GetComponent<CoreColor>();
            credits = GameObject.Find("CreditsStuff").GetComponent<CreditsController>();
        }
    }
}