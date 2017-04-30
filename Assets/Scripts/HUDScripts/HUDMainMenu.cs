using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDMainMenu : MonoBehaviour {

	public Button[] buttons;
	// Use this for initialization
	void Start () {
		buttons = this.gameObject.transform.GetChild(0).GetComponentsInChildren<Button>();
		buttons[0].onClick.AddListener(StartGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void StartGame()
	{
		SceneManager.LoadScene ("Ship Select",LoadSceneMode.Single);
	}
}
