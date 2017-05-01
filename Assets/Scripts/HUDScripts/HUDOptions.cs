using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDOptions : MonoBehaviour {

	public Slider musicSlider;
	public AudioSource music;
	bool active = false;
	float t;
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
		t=0;
		if(musicSlider.name == "musicSlider")
		{
			active = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		t+=Time.deltaTime;
		if(transform.childCount > 4)
		{
			active = true;
		}
		else
		{
			active = false;
		}
		if(!active){return;}
		float horizontal = Input.GetAxis ("Horizontal");
		if(horizontal <= -1f &&  t > .3f)
		{
			musicSlider.value -= 1f;
			t = 0;
		}
		else if(horizontal >= 1f &&  t > .3f)
		{
			musicSlider.value += 1f;
			t = 0;
		}
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
