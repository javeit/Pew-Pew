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
		delays[3,0] = 16f;
		delays[4,0] = dialogue[3].clip.length;
		delays[5,0] = dialogue[4].clip.length;
		delays[6,0] = dialogue[5].clip.length;
		delays[7,0] = dialogue[6].clip.length;
	}
	
	// Update is called once per frame 
	void Update () {
		time += Time.deltaTime;
		if(count != dialogue.Length  &&  time > delays[count,0])
		{
			dialogue[count].Play();
			count++;
			time = 0f;
		}
	}
}
