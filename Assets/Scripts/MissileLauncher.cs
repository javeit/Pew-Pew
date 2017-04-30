using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scripts for missile launching enemy
public class MissileLauncher : MonoBehaviour
{
    GameObject player;
    GameObject path;
    public Transform rocket;
    Vector3 goal;
    Vector3 rand;
    string State;
    int timer;
    int moveSide;
    MonoBehaviour fire;

    //Start, do I need to explain this?
    void Start()
    {
        path = GameObject.FindGameObjectWithTag("PathObject");
        player = GameObject.FindGameObjectWithTag("Player");
        fire = (MonoBehaviour)GetComponent("GruntWeaponScript");
        State = "IDLE";
        moveSide = 0;
        rand = new Vector3(Random.Range(-6f, 6f), Random.Range(-15f, 15f), Random.Range(-6f, 6f));
        timer = 80;
        fire.enabled = false;
    }

    //Contains the state machine for the missile launcher
    void Update()
    {

        if (State.Equals("ACTIVE"))
        {
            //upon being activated it moves to the middle of the screen
            iTween.LookUpdate(gameObject, iTween.Hash("looktarget", goal, "speed", 1.0f));
            goal = path.transform.position + (path.transform.forward * 80) + rand;

            iTween.MoveUpdate(gameObject, iTween.Hash("position", goal, "time", 3.2f));
            if (Mathf.Abs(transform.position.x - goal.x) < 2 && Mathf.Abs(transform.position.y - goal.y) < 2 && Mathf.Abs(transform.position.z - goal.z) < 2)
                attack();


        }
        else if (State.Equals("ATTACK"))
        {
            //strafes back and forth and launches missile volleys
            if (timer >= 125)
            {
                if (timer % 25 == 0)
                    LaunchMissile();
            }
            timer++;

            if (timer >= 200)
                timer = 0;

            iTween.LookUpdate(gameObject, iTween.Hash("looktarget", player.transform.position, "speed", 1.0f));

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

    //transitions to the attack state
    public void attack()
    {
        State = "ATTACK";
        fire.enabled = true;
    }

    //activates the enemy
    public void Activate()
    {
        transform.parent = path.transform;
        State = "ACTIVE";
    }

    public void LaunchMissile()
    {
        Transform rocketClone = (Transform)Instantiate(rocket,transform.position + (path.transform.up * 10), transform.rotation);
        rocketClone.transform.position = transform.position + (path.transform.up *10);
     }


}
