using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderScript : MonoBehaviour {

	public Slider musicSlider;
	public int health;
	public CoreColor healthObject;
	// Use this for initialization
	void Start () {
		healthObject = GameObject.Find("PlayerShip_Crystal").GetComponent<CoreColor>();
	}
	
	// Update is called once per frame
	void Update () {
		musicSlider.value = healthObject.coreHP;
	}
}
