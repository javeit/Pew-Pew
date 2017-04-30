using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDLearn : MonoBehaviour {

	public Button backButton;
	// Use this for initialization
	void Start () {
		backButton.onClick.AddListener(GoBack);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void GoBack()
	{
		SceneManager.LoadScene ("Main Menu",LoadSceneMode.Single);
	}
}
