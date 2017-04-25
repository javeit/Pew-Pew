using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    GameObject player;
    GameObject path;
    GameObject target;
    Vector3 goal;
    int timer;
    string State;
    int moveSide;
    // Use this for initialization


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("MissileTarget");
        path = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
        State = "IDLE";

        timer = 0;
        moveSide = 0;
    }

    // Update is called once per frame
    void Update()
    {

  
        if (State.Equals("ATTACK"))
        {
            iTween.LookUpdate(gameObject, target.transform.position, .2f);
            iTween.MoveUpdate(gameObject, target.transform.position, 4.0f);
        }
        else if (State.Equals("DISABLE"))
        {
            transform.parent = null;

        }

    }



    public void Activate()
    {
        transform.parent = path.transform;
        State = "ATTACK";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MissileTarget"))
            State = "DISABLE";
    }

}
