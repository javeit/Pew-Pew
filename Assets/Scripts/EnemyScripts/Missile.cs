using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for enemy missiles to guide them to the player
public class Missile : MonoBehaviour
{
    GameObject path;
    GameObject target;
    Vector3 goal;
    int timer;
    string State;

	private AudioSource explodeSound;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("MissileTarget");
        path = GameObject.FindGameObjectWithTag("MainCamera");
		explodeSound = GameObject.Find ("MissileExplodeSound").GetComponent<AudioSource> ();

        timer = 0;
        transform.parent = path.transform;
        State = "ATTACK";
    }


    //Basic, 2 States, while in attack it moves to and looks at the target, upon hitting the target it destroys itself.
    //Target is an empty gameobject trailing behind the player, allowing it to move towards the player, but letting the player dodge it
    void Update()
    {

        if (State.Equals("ATTACK"))
        {
            iTween.LookUpdate(gameObject, target.transform.position, .2f);
            iTween.MoveUpdate(gameObject, target.transform.position, 9.0f);
        }
        else if (State.Equals("DISABLE"))
        {
            transform.parent = null;
            timer++;
            if(timer>20)
                Destroy(gameObject);
        }

    }


    //Activates the missile to begin trackin the player
    public void Activate()
    {
      //  transform.parent = path.transform;
        State = "ATTACK";
    }


    //Upon Hitting our target we should disable the missile
    void OnTriggerEnter(Collider other)
    {
		explodeSound.Play ();
  
        if (other.CompareTag("MissileTarget"))
            State = "DISABLE";
        if (other.CompareTag("Player"))
            print("hit");
    }

 
}
