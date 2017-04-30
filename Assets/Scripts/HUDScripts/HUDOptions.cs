using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDOptions : MonoBehaviour {

	public Slider musicSlider;
	public AudioSource music;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		musicSlider.onValueChanged.AddListener(changeVolume);
	}
	
	void changeVolume(float value)
	{
		music.Stop();
		music.volume = musicSlider.value / 20;
		music.Play();
	}
}
