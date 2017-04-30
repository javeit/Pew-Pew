using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDMainMenu : MonoBehaviour {

	Button[] buttons;
	// Use this for initialization
	void Start () {
		buttons = this.gameObject.transform.GetChild(0).GetComponentsInChildren<Button>();
		buttons[0].onClick.AddListener(StartGame);
		buttons[1].onClick.AddListener(LearnMore);
		buttons[2].onClick.AddListener(Options);
		buttons[3].onClick.AddListener(About);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void StartGame()
	{
		SceneManager.LoadScene ("Ship Select",LoadSceneMode.Single);
	}
	
	void LearnMore()
	{
		SceneManager.LoadScene ("Learn More",LoadSceneMode.Single);
	}
	void About()
	{
		SceneManager.LoadScene ("About",LoadSceneMode.Single);
	}
	
	void Options()
	{
		SceneManager.LoadScene ("Options",LoadSceneMode.Single);
	}
}
