using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDShipSelect : MonoBehaviour {

	Button[] buttons;
	public Button startButton;
	public Button backButton;
	public LRSelectBoxScript selectScript;
	public GameObject startSelectBox;
	public GameObject backSelectBox;
	bool startSelected = false;
	// Use this for initialization
	void Start () {
		buttons = this.gameObject.transform.GetChild(0).GetComponentsInChildren<Button>();
		startButton.onClick.AddListener(StartGame);
		backButton.onClick.AddListener(GoBack);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("down") && startSelected == false)
		{
			StartSelected();
		}
		else if(Input.GetKeyDown("up") && startSelected)
		{
			StartDeselected();
		}
		else if(Input.GetKeyDown("return") && startSelected)
		{
			StartGame();
		}
		
	}
	
	void StartGame()
	{
		PlayerPrefs.SetInt("ShipSelect", selectScript.getIndex());
		SceneManager.LoadScene ("Test Scene",LoadSceneMode.Single);
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
