using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDScript : MonoBehaviour {
	public Button pauseButton;
	public GameObject pauseMenu;
	public GameObject[] hearts;
	public GameObject[] lives;
	public GameObject[] weaponBoxes;
	public GameObject dialogueBox;
	public GameObject selectBox;
	public GameObject[] pauseButtons;
	private GameObject pauseButtonGo;
	private bool paused = false;
	private int heartsLeft = 2;
	private float dialogueStart = 0;
	static private int livesLeft = 2;
	private float dialogueRightX = 481;
	private float dialogueLeftX = 338;
	private bool sendInDialogue = false;
	private float t;
	private Vector3 oldPos;
	private Vector3 target;
	private Vector3 startPosition;
	private bool sent = false;
	private GameObject[] shipModels;
	private int index;
	float timeToReachTarget;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1.0F;
		int shipSelect = PlayerPrefs.GetInt("ShipSelect");
		shipModels = GameObject.FindGameObjectsWithTag("shipModels");
		if(shipSelect == 2)
		{
			shipModels[1].SetActive(false);
			shipModels[2].SetActive(false);
		}
		else if(shipSelect == 1)
		{
			shipModels[0].SetActive(false);
			shipModels[2].SetActive(false);
		}
		else if(shipSelect == 0)
		{
			shipModels[0].SetActive(false);
			shipModels[1].SetActive(false);
		}
		else{
			shipModels[1].SetActive(false);
			shipModels[2].SetActive(false);
		}
		if(livesLeft <= 1){Destroy(lives[2]);}
		if(livesLeft <= 0){Destroy(lives[1]);}
		if(livesLeft <= -1){Destroy(lives[0]);}
		for(int i=1;i<weaponBoxes.Length;i++)
		{
			weaponBoxes[i].SetActive(false);
		}
		Button btn = pauseButton.GetComponent<Button>();
		btn.onClick.AddListener(PauseGame);
		pauseButtonGo = GameObject.Find("pauseButton");
		oldPos = target = dialogueBox.GetComponent<RectTransform>().anchoredPosition;
		Debug.Log(oldPos.ToString());
	}
	
	// Update is called once per frame
	void Update () { 
		t += Time.deltaTime/timeToReachTarget;
		dialogueBox.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(startPosition,target,t);
		if(Time.timeSinceLevelLoad >= 5&& Time.timeSinceLevelLoad <6)
		{
			MoveObject(new Vector3(dialogueRightX,oldPos.y,oldPos.z),1.0f);
		}
		if(Time.timeSinceLevelLoad >= 10&& Time.timeSinceLevelLoad <11)
		{
			MoveObject(new Vector3(dialogueLeftX,oldPos.y,oldPos.z),1.0f);
		}
		if(Input.GetKeyDown("escape"))
		{
			PauseGame();
		}
		if(paused)
		{
			index = Array.IndexOf(pauseButtons,selectBox.transform.parent.gameObject);
			if(Input.GetKeyDown("down") && index != 2)
			{
				selectBox.transform.SetParent(pauseButtons[index + 1].transform,false);
			}
			else if(Input.GetKeyDown("up") && index != 0)
			{
				selectBox.transform.SetParent(pauseButtons[index - 1].transform,false);
			}
			else if(Input.GetKeyDown("return"))
			{
				pauseButtons[index].GetComponent<Button>().onClick.Invoke();
			}
		}
		
	}
	
	void PauseGame()
	{
		Debug.Log("GOT");
		if(paused)
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Locked;
			pauseMenu.SetActive(false);
			paused = false;
			Time.timeScale = 1.0F;
		}
		else{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Confined;
			pauseMenu.SetActive(true);
			paused = true;
			Time.timeScale = 0.0F;
			pauseButtons[0].GetComponent<Button>().onClick.AddListener(PauseGame);
			pauseButtons[1].GetComponent<Button>().onClick.AddListener(RestartGame);
			pauseButtons[2].GetComponent<Button>().onClick.AddListener(QuitGame);
		}
		Debug.Log("Pause");
	}
	public bool getPaused()
	{
		return paused;
	}
	public void decrimentHearts()
	{
			if(heartsLeft >= 0)
			{
				Destroy(hearts[heartsLeft]);
				heartsLeft--;
			}
			if(heartsLeft < 0)
			{
				livesLeft--;
				heartsLeft = 2;
				SceneManager.LoadScene ("Test Scene",LoadSceneMode.Single);
			}
	}
	public void setWeaponActive(int num)
	{
		for(int i=0;i<weaponBoxes.Length;i++)
		{
			weaponBoxes[i].SetActive(false);
		}
		if(num == 0)
		{
			weaponBoxes[0].SetActive(true);
		}
		else if(num == 1)
		{
			weaponBoxes[1].SetActive(true);
		}
		else if(num == 2)
		{
			weaponBoxes[2].SetActive(true);
		}
		
	}
	
	public void MoveObject(Vector3 destination,float time)
	{
		t = 0;
        startPosition = dialogueBox.GetComponent<RectTransform>().anchoredPosition;
        timeToReachTarget = time;
        target = destination; 
	}
	
	public void RestartGame()
	{
		SceneManager.LoadScene ("Ship Select",LoadSceneMode.Single);
	}
	public void QuitGame()
	{}
	public void setIndex(int i)
	{
		selectBox.transform.SetParent(pauseButtons[i].transform,false);
		index = i;
	}
}
