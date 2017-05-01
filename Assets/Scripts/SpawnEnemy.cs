using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	public GameObject shipToSpawn;
	public Transform spawnAnchor;
	public Vector3 spawnOffset = new Vector3(0f,0f,0f);

	private bool hasSpawned = false;
	// Use this for initialization

	void Start () {}
	
	// Update is called once per frame
	void Update () {
		if (hasSpawned == false) {
			GameObject newEnemy = Instantiate (shipToSpawn, spawnAnchor);
			newEnemy.transform.localPosition = spawnOffset;
			hasSpawned = true;
		}
	}
}
