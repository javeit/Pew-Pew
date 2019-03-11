using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBoxPause : MonoBehaviour {
Button[] buttons;
	int index;
	float timeStart;
	public float t;
	// Use this for initialization
	void Start () {
		buttons = this.gameObject.transform.parent.parent.GetComponentsInChildren<Button>();
		timeStart = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		index = Array.IndexOf(buttons,this.transform.parent.gameObject.GetComponent<Button>());
		float horizontalMove = Input.GetAxis ("Vertical");
		t = Time.realtimeSinceStartup - timeStart;
		if((Input.GetKeyDown("down") || horizontalMove <= -1f) && index != buttons.Length -1 && t > .3f)
		{
			this.transform.SetParent(buttons[index + 1].transform,false);
			timeStart = Time.realtimeSinceStartup;
		}
		else if((Input.GetKeyDown("up") || horizontalMove >= 1f) && index != 0 && t > .3f)
		{
			this.transform.SetParent(buttons[index - 1].transform,false);
			timeStart = Time.realtimeSinceStartup;
		}
		else if(Input.GetKeyDown("return") || Input.GetKeyDown("joystick button 0"))
		{
			buttons[index].GetComponent<Button>().onClick.Invoke();
		}
	}
	
	public void setIndex(int i)
	{
		this.transform.SetParent(buttons[i].transform,false);
		index = i;
	}
}
