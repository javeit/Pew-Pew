using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//pretty simple script, its just a target to guide the missiles, it sits behind the player so that the missiles
//move in the general direction of the player, but can be dodged. Offset controls how close it is behind the player.
public class MissileTarget : MonoBehaviour {

    GameObject player;
    public int offset;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
    //Moves the missile target to a position behind the player.
	void LateUpdate () {
        Vector3 goal = player.transform.position - (player.transform.forward * offset);
        transform.position = goal;
	}

   
}
