using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDOptionsCanv : MonoBehaviour {

	Slider activeSlider;
	public GameObject selectBox;
	float t;
	// Use this for initialization
	void Start () {
		SetActiveSlider(GameObject.Find("musicSlider").GetComponent<Slider>());
	}
	
	// Update is called once per frame
	void Update () {
		t+=Time.deltaTime;
		float horizontalMove = Input.GetAxis ("Vertical");
		if((Input.GetKeyDown("down") || horizontalMove <= -1f) && t > .3f)
		{
			if(activeSlider.name == "dialogueSlider"){}
			else if(activeSlider.name == "musicSlider"){
				SetActiveSlider(GameObject.Find("fxSlider").GetComponent<Slider>());
			}
			else if(activeSlider.name == "fxSlider"){
				SetActiveSlider(GameObject.Find("dialogueSlider").GetComponent<Slider>());
			}
			
			t = 0;
		}
		else if((Input.GetKeyDown("up") || horizontalMove >= 1f) && t > .3f)
		{
			if(activeSlider.name == "musicSlider"){}
			else if(activeSlider.name == "fxSlider"){
				SetActiveSlider(GameObject.Find("musicSlider").GetComponent<Slider>());
			}
			else if(activeSlider.name == "dialogueSlider"){
				SetActiveSlider(GameObject.Find("fxSlider").GetComponent<Slider>());
			}
			
			t = 0;
		}
	}
	
	public void SetActiveSlider(Slider s)
	{
		activeSlider = s;
		selectBox.transform.SetParent(s.transform,false);
	}
	
	public void GoBack()
	{
		SceneManager.LoadScene ("Main Menu",LoadSceneMode.Single);
	}
}
