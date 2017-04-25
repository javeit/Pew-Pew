using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTarget : MonoBehaviour {

    GameObject player;
    public int offset;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
       // offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 goal = player.transform.position - (player.transform.forward * offset);
        transform.position = goal;
	}

   
}
