using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL1DialogueScript : MonoBehaviour {

	public GameObject sources;
	public AudioSource[] dialogue;
	public MoveDialogueScript moveScript;
	public float[,] delays;
	public float time = 0;
	public int count = 0;
	// Use this for initialization
	void Start () {
		dialogue = sources.GetComponents<AudioSource>();
		moveScript = GameObject.Find("Dialogue").GetComponent<MoveDialogueScript>();
		delays = new float[dialogue.Length,2];
		delays[0,0] = 2f;
		delays[1,0] = dialogue[0].clip.length;
		delays[2,0] = dialogue[1].clip.length;
		delays[3,0] = 5f;
		delays[4,0] = dialogue[3].clip.length;
		delays[5,0] = 15f;
		delays[6,0] = 7f;
		delays[7,0] = dialogue[6].clip.length;
		delays[8,0] = dialogue[7].clip.length;
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
			else if(count == 3)
			{
				moveScript.SetDialogueOut(1);
			}
			else if(count == 5)
			{
				moveScript.SetDialogueOut(0);
			}
			else if(count == 6)
			{
				moveScript.SetDialogueOut(1);
			}
			dialogue[count].Play();
			count++;
			time = 0f;
			if(count == 3  || count == 5 || count == 6 || count == dialogue.Length)
			{
				moveScript.SetDialogueIn(dialogue[count -1].clip.length);
			}
		}
	}
}
