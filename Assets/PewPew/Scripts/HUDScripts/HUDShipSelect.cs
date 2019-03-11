using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDShipSelect : MonoBehaviour {

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
		Debug.Log(selectScript.getIndex());
		PlayerPrefs.SetInt("ShipSelect", selectScript.getIndex());
		SceneManager.LoadScene ("Level Select",LoadSceneMode.Single);
	}
	void GoBack()
	{
		SceneManager.LoadScene ("Main Menu",LoadSceneMode.Single);
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
