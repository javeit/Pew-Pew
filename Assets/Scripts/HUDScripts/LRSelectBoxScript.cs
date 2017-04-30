using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LRSelectBoxScript : MonoBehaviour {
	Button[] buttons;
	private int index;
	// Use this for initialization
	void Start () {
		buttons = this.gameObject.transform.parent.parent.GetComponentsInChildren<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		index = Array.IndexOf(buttons,this.transform.parent.gameObject.GetComponent<Button>());
		if(Input.GetKeyDown("right") && index != buttons.Length -1)
		{
			this.transform.SetParent(buttons[index + 1].transform,false);
		}
		else if(Input.GetKeyDown("left") && index != 0)
		{
			this.transform.SetParent(buttons[index - 1].transform,false);
		}
		else if(Input.GetKeyDown("return"))
		{
			buttons[index].GetComponent<Button>().onClick.Invoke();
		}
	}
	
	public int getIndex()
	{
		return index;
	}
	
	public void setIndex(int i)
	{
		this.transform.SetParent(buttons[i].transform,false);
		index = i;
	}
}
