using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTarget : MonoBehaviour {

    GameObject player;
    Vector3 offset;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
       // offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        offset = player.transform.forward.normalized;
        offset.Scale(new Vector3(5,5,5));
        Vector3 goal = player.transform.position - (player.transform.forward * 8);
        transform.position = goal;
	}

   
}
