using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreWaveSpawn : MonoBehaviour {
	//Defenders
	public GameObject [] defenders;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider thing) {
		Vector3 spawnPointB = new Vector3 (Random.Range(-10.0f, 10.0f), -70, Random.Range (-10.0f, 10.0f));
		Instantiate (defenders [Random.Range (0, defenders.Length)], gameObject.transform.position + spawnPointB, Quaternion.identity);
	}
}
