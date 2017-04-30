using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDScript : MonoBehaviour {
	public Button pauseButton;
	public GameObject[] hearts;
	public GameObject[] lives;
	public GameObject[] weaponBoxes;
	public GameObject dialogueBox;
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
	float timeToReachTarget;
	// Use this for initialization
	void Start () {
		int shipSelect = PlayerPrefs.GetInt("ShipSelect");
		shipModels = GameObject.FindGameObjectsWithTag("shipModels");
		if(shipSelect == 0)
		{
			shipModels[1].SetActive(false);
			shipModels[2].SetActive(false);
		}
		else if(shipSelect == 1)
		{
			shipModels[0].SetActive(false);
			shipModels[2].SetActive(false);
		}
		else if(shipSelect == 2)
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
		
	}
	
	void PauseGame()
	{
		Debug.Log("GOT");
		if(paused)
		{
			paused = false;
			Time.timeScale = 1.0F;
		}
		else{
			paused = true;
			
			Time.timeScale = 0.0F;
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
}
