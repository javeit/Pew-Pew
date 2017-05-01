using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL2DialogueScript : MonoBehaviour {
	public GameObject sources;
	public AudioSource[] dialogue;
	public MoveDialogueScript moveScript;
	public float[,] delays;
	public float time = 0;
	public int count = 0;
	float volume;
	// Use this for initialization
	void Start () {
		volume = PlayerPrefs.GetFloat("dialogueVol");
		dialogue = sources.GetComponents<AudioSource>();
		moveScript = GameObject.Find("Dialogue").GetComponent<MoveDialogueScript>();
		delays = new float[dialogue.Length,2];
		delays[0,0] = 2f;
	}
	
	// Update is called once per frame 
	void Update () {
		time += Time.deltaTime;
		if(count != dialogue.Length  &&  time > delays[count,0])
		{
			if(count == 0)
			{
				moveScript.SetDialogueOut(0);
			}
			dialogue[count].volume = volume;
			dialogue[count].Play();
			count++;
			time = 0f;
			if(count == dialogue.Length)
			{
				moveScript.SetDialogueIn(dialogue[count -1].clip.length);
			}
		}
	}
}
