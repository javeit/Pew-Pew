using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
	GameObject player;
	string State;
	GameObject path;
	Vector3 goal;
	int timer;
	int moveSide;
    Vector3 rand;
	// Use this for initialization


	void Start () {
		path= GameObject.FindGameObjectWithTag ("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
		State= "IDLE";

		timer = 0;
		moveSide = 0;
        rand = new Vector3(Random.Range(-6f,6f), Random.Range(-25f, 25f), Random.Range(-6f, 6f));
	}
	
	// Update is called once per frame
	void Update () {
		
		if (State.Equals("ACTIVE")) {
			print ("ACTIVE");

            iTween.LookUpdate(gameObject, iTween.Hash("looktarget", goal, "speed", 1.0f));
            goal = path.transform.position + (path.transform.forward*50) + rand;
            
             iTween.MoveUpdate(gameObject, iTween.Hash("position", goal, "time", 3.2f));
            if (Mathf.Abs(transform.position.x - goal.x) < 2 && Mathf.Abs(transform.position.y - goal.y) < 2 && Mathf.Abs(transform.position.z - goal.z) < 2)
                parent();
		
		
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
	}

	public void Activate()
	{
        transform.parent = path.transform;
        State = "ACTIVE";
	}



}
