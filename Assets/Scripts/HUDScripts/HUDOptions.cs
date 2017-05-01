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
		
		if(musicSlider.name == "musicSlider")
		{
			musicSlider.value = PlayerPrefs.GetFloat("musicVol") * 20f;
		}
		else if(musicSlider.name == "fxSlider")
		{
			musicSlider.value = PlayerPrefs.GetFloat("fxVol") * 20f;
		}
		else if(musicSlider.name == "dialogueSlider")
		{
			musicSlider.value = PlayerPrefs.GetFloat("dialogueVol") * 20f;
		}
		musicSlider.onValueChanged.AddListener(changeVolume);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void changeVolume(float value)
	{
		if(musicSlider.name == "musicSlider")
		{
			PlayerPrefs.SetFloat("musicVol", musicSlider.value / 20f);
		}
		else if(musicSlider.name == "fxSlider")
		{
			PlayerPrefs.SetFloat("fxVol", musicSlider.value / 20f);
		}
		else if(musicSlider.name == "dialogueSlider")
		{
			PlayerPrefs.SetFloat("dialogueVol", musicSlider.value / 20f);
		}
		music.Stop();
		music.volume = musicSlider.value / 20;
		music.Play();
		PlayerPrefs.Save();
		
	}
}
