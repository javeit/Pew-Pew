using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDAbout : MonoBehaviour {

	public Button back;
	// Use this for initialization
	void Start () {
		back.onClick.AddListener(goBack);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void goBack()
	{
		SceneManager.LoadScene ("Main Menu",LoadSceneMode.Single);
	}
}
