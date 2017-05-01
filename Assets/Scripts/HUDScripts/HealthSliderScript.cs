using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderScript : MonoBehaviour {

	public Slider healthSlider;
	CoreColor corScript;
	HUDCreditsScript credits;
	bool calledCredits = false;
	//public int health;
	// Use this for initialization
	void Start () {
		corScript = GameObject.Find("CapitalCore").GetComponent<CoreColor>();
		credits = GameObject.Find("CreditsStuff").GetComponent<HUDCreditsScript>();
	}
	
	// Update is called once per frame
	void Update () {
		healthSlider.value = corScript.coreHP;
		if(!calledCredits && corScript.coreHP <= 0)
		{
			credits.StartRoll();
			calledCredits = true;
		}
	}
}
