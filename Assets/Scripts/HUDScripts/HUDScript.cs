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
	public GameObject shield;
	public GameObject[] lives;
	public GameObject[] weaponBoxes;
	public GameObject dialogueBox;
	public GameObject selectBox;
	public GameObject[] pauseButtons;
	private AudioSource music;
	private AudioSource laserShot;
	private AudioSource gruntShot;
	private AudioSource missileShot;
	private AudioSource missileExplode;
	private GameObject pauseButtonGo;
	private bool paused = false;
	private int heartsLeft = 2;
	static private int livesLeft = 2;
	private float t;
	private Vector3 startPosition;
	private GameObject[] shipModels = new GameObject[3];
	private int index;
	private bool shieldUp = true;
	float timeToReachTarget;
	float timeSinceShieldGone;
	// Use this for initialization
	void Start () {
		music = GameObject.Find("Main Camera").GetComponent<AudioSource>();
		music.volume = PlayerPrefs.GetFloat("musicVol")/6f;
		laserShot = GameObject.Find("Player Aim").GetComponent<AudioSource>();
		laserShot.volume = PlayerPrefs.GetFloat("fxVol");
		gruntShot = GameObject.Find ("GruntSound").GetComponent<AudioSource> ();
		gruntShot.volume = 0.5F * PlayerPrefs.GetFloat("fxVol");
		missileShot = GameObject.Find ("MissileLaunchSound").GetComponent<AudioSource> ();
		missileShot.volume = PlayerPrefs.GetFloat ("fxVol");
		missileExplode = GameObject.Find ("MissileExplodeSound").GetComponent<AudioSource>();
		missileExplode.volume = PlayerPrefs.GetFloat ("fxVol");
		Time.timeScale = 1.0F;
		int shipSelect = PlayerPrefs.GetInt("ShipSelect");
		shipModels[0] = GameObject.Find("PlayerShip_Crystal");
		shipModels[1] = GameObject.Find("JediStarfighter");
		shipModels[2] = GameObject.Find("SwordFish");
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
	}
	
	// Update is called once per frame
	void Update () { 
		timeSinceShieldGone += Time.deltaTime;
		if(timeSinceShieldGone > 5f && shieldUp == false)
		{
			shield.SetActive(true);
			shieldUp = true;
		}
		if(Input.GetKeyDown("escape") || Input.GetKeyDown("joystick button 7"))
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
	
	public void PauseGame()
	{
		if(paused)
		{
			Cursor.visible = false;
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
	}
	public bool getPaused()
	{
		return paused;
	}
	public void decrimentHearts()
	{
			if(shieldUp = true)
			{
				shield.SetActive(false);
				timeSinceShieldGone = 0f;
				shieldUp = false;
				return;
			}
			if(heartsLeft >= 0)
			{
				Destroy(hearts[heartsLeft]);
				heartsLeft--;
			}
			if(heartsLeft < 0)
			{
				livesLeft--;
				heartsLeft = 2;
				SceneManager.LoadScene (Application.loadedLevel,LoadSceneMode.Single);
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
	
	public void RestartGame()
	{
		pauseMenu.SetActive(false);
		paused = false;
		Time.timeScale = 1.0F;
		livesLeft = 2;
		SceneManager.LoadScene ("Ship Select",LoadSceneMode.Single);
	}
	public void QuitGame()
	{
	}
	public void setIndex(int i)
	{
		selectBox.transform.SetParent(pauseButtons[i].transform,false);
		index = i;
	}
}
