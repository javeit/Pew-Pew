using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL3DialogueScript : MonoBehaviour {
	public GameObject sources;
	public AudioSource[] dialogue;
	public MoveDialogueScript moveScript;
	public float[,] delays;
	public float time = 0;
	public int count = 0;
	public EnemyPartHealth health;
	public CoreColor coreHealth;
	bool exposed = false;
	bool credits = false;
	float volume;
	// Use this for initialization
	void Start () {
		health = GameObject.Find("Breakaway").GetComponent<EnemyPartHealth>();
		coreHealth = GameObject.Find("CapitalCore").GetComponent<CoreColor>();
		volume = PlayerPrefs.GetFloat("dialogueVol");
		dialogue = sources.GetComponents<AudioSource>();
		moveScript = GameObject.Find("Dialogue").GetComponent<MoveDialogueScript>();
		delays = new float[dialogue.Length,2];
		delays[0,0] = 2f;//trench
		delays[1,0] = 30f;//gdit
		delays[2,0] = 10f;//expose
		delays[3,0] = 10f;//fake
		delays[4,0] = 20f;//wouldnt fall
		delays[5,0] = 5f;//shoot
		delays[6,0] = 4f;//dont shoot
		delays[7,0] = 1f;//no
		delays[8,0] = 4f;//thank you
		
	}
	
	// Update is called once per frame 
	void Update () {
		time += Time.deltaTime;
		if(health.pathChange)
		{
			exposed = true;
		}
		if(coreHealth.coreHP <= 0)
		{
			credits = true;
		}
		if(count != dialogue.Length  &&  time > delays[count,0])
		{
			if(count == 5 && !exposed)
			{
				time = 0;
				return;
			}
			else if(count == 7 && !credits)
			{
				return;
			}
			if(count == 0 || count == 1 || count == 4 || count ==6 || count == 7)
			{
				moveScript.SetDialogueOut(1);
			}
			else if(count == 2 || count == 3 || count == 5 || count == 8)
			{
				moveScript.SetDialogueOut(0);
			}
			
			dialogue[count].volume = volume;
			dialogue[count].Play();
			count++;
			time = 0f;
			if(true)
			{
				moveScript.SetDialogueIn(dialogue[count -1].clip.length);
			}
		}
	}
}
