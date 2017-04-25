using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
	public PlayerController player;
	string State;
	GameObject path;
	Vector3 goal;
	bool moving;
	int timer;
	int moveSide;
	// Use this for initialization


	void Start () {
		path= GameObject.FindGameObjectWithTag ("MainCamera");
		State= "IDLE";
		moving = false;
		timer = 0;
		moveSide = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (State.Equals("ACTIVE")) {
			transform.parent = path.transform;
			print ("ACTIVE");
			goal = path.transform.position + (path.transform.forward*50);
			if (!moving)
				iTween.MoveTo (gameObject, iTween.Hash ("position", goal, "time", .2f,"oncomplete", "parent"));
			moving = true;
		
		
		}
		else if(State.Equals("ATTACK"))
		{
			iTween.LookUpdate (gameObject, iTween.Hash ("looktarget", player.transform.position, "speed", 1.0f));
			if (timer > 350)
				State = "DISABLE";
			timer= timer + 1;
			if (moveSide < 50) {
				transform.position = transform.position + (path.transform.right.normalized * .15f);
				moveSide++;
			}
			if (moveSide >= 50) {
				transform.position = transform.position - (path.transform.right.normalized * .15f);
				moveSide++;
			}
			if (moveSide == 100)
				moveSide = 0;
		}
		else if(State.Equals("DISABLE"))
		{
			transform.parent = null;
	
		}

	}

	public void parent()
	{
		State = "ATTACK";
		//transform.parent = path.transform;
	}

	public void Activate()
	{
		State = "ACTIVE";
	}



}
