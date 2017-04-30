using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDShipSelect : MonoBehaviour {

	public Button[] buttons;
	// Use this for initialization
	void Start () {
		buttons = this.gameObject.transform.GetChild(0).GetComponentsInChildren<Button>();
		buttons[0].onClick.AddListener(SetCrystal);
		buttons[1].onClick.AddListener(SetStarfighter);
		buttons[2].onClick.AddListener(SetSwordfish);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void SetCrystal()
	{
		PlayerPrefs.SetInt("ShipSelect", 0);
		SceneManager.LoadScene ("Test Scene",LoadSceneMode.Single);
	}
	void SetStarfighter()
	{
		PlayerPrefs.SetInt("ShipSelect", 1);
		SceneManager.LoadScene ("Test Scene",LoadSceneMode.Single);
	}
	void SetSwordfish()
	{
		PlayerPrefs.SetInt("ShipSelect", 2);
		SceneManager.LoadScene ("Test Scene",LoadSceneMode.Single);
	}
}
