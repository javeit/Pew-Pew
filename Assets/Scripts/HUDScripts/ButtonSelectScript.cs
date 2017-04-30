using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectScript : MonoBehaviour {

	public Button thisButton;
	public GameObject selectBox;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void overButton()
	{
		selectBox.SetActive(true);
	}
	
	public void abandonButton()
	{
		selectBox.SetActive(false);
	}
	
}
