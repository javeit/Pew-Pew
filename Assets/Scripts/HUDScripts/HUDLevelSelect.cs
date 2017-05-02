using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDLevelSelect : MonoBehaviour {

	public Button startButton;
	public Button backButton;
	public LRSelectBoxScript selectScript;
	public GameObject startSelectBox;
	public GameObject backSelectBox;
	bool startSelected = false;
	// Use this for initialization
	void Start () {
		startButton.onClick.AddListener(StartGame);
		backButton.onClick.AddListener(GoBack);
	}
	
	// Update is called once per frame
	void Update () {
		float verticle = Input.GetAxis ("Vertical");
		if((Input.GetKeyDown("down") || verticle <= -1f ) && startSelected == false)
		{
			StartSelected();
		}
		else if((Input.GetKeyDown("up") || verticle >= 1f) && startSelected)
		{
			StartDeselected();
		}
		else if((Input.GetKeyDown("return") || Input.GetKeyDown("joystick button 0")) && startSelected)
		{
			StartGame();
		}
		
	}
	
	void StartGame()
	{
		//PlayerPrefs.SetInt("ShipSelect", selectScript.getIndex());
		if(selectScript.getIndex() == 0)
		{
			SceneManager.LoadScene ("Test Scene",LoadSceneMode.Single);
		}
		else if(selectScript.getIndex() == 1)
		{
			SceneManager.LoadScene ("Level2",LoadSceneMode.Single);
		}
		else if(selectScript.getIndex() == 2)
		{
			SceneManager.LoadScene ("Level3",LoadSceneMode.Single);
		}
		else{
			SceneManager.LoadScene ("Test Scene",LoadSceneMode.Single);
		}
	}
	void GoBack()
	{
		SceneManager.LoadScene ("Ship Select",LoadSceneMode.Single);
	}
	public void StartSelected()
	{
		startSelectBox.SetActive(true);
		startSelected = true;
	}
	public void StartDeselected()
	{
		startSelectBox.SetActive(false);
		startSelected = false;
	}
	public void BackSelected()
	{
		backSelectBox.SetActive(true);
	}
	public void BackDeselected()
	{
		backSelectBox.SetActive(false);
	}
}
