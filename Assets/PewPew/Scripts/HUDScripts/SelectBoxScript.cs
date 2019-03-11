using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBoxScript : MonoBehaviour {
	Button[] buttons;
	int index;
	float t;
	// Use this for initialization
	void Start () {
		buttons = this.gameObject.transform.parent.parent.GetComponentsInChildren<Button>();
		t = 0;
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		index = Array.IndexOf(buttons,this.transform.parent.gameObject.GetComponent<Button>());
		float horizontalMove = Input.GetAxis ("Vertical");
		if((Input.GetKeyDown("down") || horizontalMove <= -1f) && index != buttons.Length -1 && t > .3f)
		{
			this.transform.SetParent(buttons[index + 1].transform,false);
			t = 0;
		}
		else if((Input.GetKeyDown("up") || horizontalMove >= 1f) && index != 0 && t > .3f)
		{
			this.transform.SetParent(buttons[index - 1].transform,false);
			t = 0;
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
