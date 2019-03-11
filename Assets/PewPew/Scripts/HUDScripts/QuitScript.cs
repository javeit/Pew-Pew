using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScript : MonoBehaviour {

	public GameObject menu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Quit()
	{
		Application.Quit();
		UnityEditor.EditorApplication.isPlaying = false;
	}
	
	public void Cancel()
	{
		menu.SetActive(false);
	}
}
