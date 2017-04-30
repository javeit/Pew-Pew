using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The script for our basic grunt enemies
public class EnemyBehavior : MonoBehaviour
{
    GameObject player;
    string State;
    GameObject path;
    Vector3 goal;
    int timer;
    int moveSide;
    Vector3 rand;


    void Start()
    {
        path = GameObject.FindGameObjectWithTag("PathObject");
        player = GameObject.FindGameObjectWithTag("Player");
        State = "IDLE";

        timer = 0;
        moveSide = 0;
        rand = new Vector3(Random.Range(-6f, 6f), Random.Range(-25f, 25f), Random.Range(-6f, 6f));
        
    }

    //the basic state machine for our grunts
    void Update()
    {

        if (State.Equals("ACTIVE"))
        {
            //When it activates, it moves to the middle of the screen
            iTween.LookUpdate(gameObject, iTween.Hash("looktarget", goal, "speed", 1.0f));
            goal = path.transform.position + (path.transform.forward * 50) + rand;

            iTween.MoveUpdate(gameObject, iTween.Hash("position", goal, "time", 3.2f));
            if (Mathf.Abs(transform.position.x - goal.x) < 2 && Mathf.Abs(transform.position.y - goal.y) < 2 && Mathf.Abs(transform.position.z - goal.z) < 2)
               attack();


        }
        else if (State.Equals("ATTACK"))
        {
            //Moves back and forth in front of the player
            iTween.LookUpdate(gameObject, iTween.Hash("looktarget", player.transform.position, "speed", 1.0f));
            if (timer > 350)
                State = "DISABLE";
            timer = timer + 1;
            if (moveSide < 50)
            {
                transform.position = transform.position + (path.transform.right.normalized * .15f);
                moveSide++;
            }
            if (moveSide >= 50)
            {
                transform.position = transform.position - (path.transform.right.normalized * .15f);
                moveSide++;
            }
            if (moveSide == 100)
                moveSide = 0;
        }
        else if (State.Equals("DISABLE"))
        {
            //eventually deparents the enemy
            transform.parent = null;

        }

    }

    //transitions to the attack state when called
    public void attack()
    {
        State = "ATTACK";
    }

    //activates the enemy
    public void Activate()
    {
        transform.parent = path.transform;
        State = "ACTIVE";
    }



}
