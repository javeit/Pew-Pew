using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDOptionsCanv : MonoBehaviour {

	Slider activeSlider;
	public GameObject selectBox;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
