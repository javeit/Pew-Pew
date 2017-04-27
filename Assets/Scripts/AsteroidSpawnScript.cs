using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnScript : MonoBehaviour {

	//array of objects to spawn
	public GameObject [] Asteroids;


	//many?
	public bool denseAsteroidField;

	// Use this for initialization
	void Start () {
		StartCoroutine (GenerateAsteroids ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//coroutine to spawn asteroids
	IEnumerator GenerateAsteroids() {
		while (true) {
			//spawn on Right
			Vector3 spawnPoint = new Vector3 (70, Random.Range (-10.0f, 10.0f), Random.Range (-10.0f, 10.0f));
			Instantiate (Asteroids [Random.Range (0, Asteroids.Length)], gameObject.transform.position + spawnPoint, Quaternion.identity);

			//Spawn of left
			Vector3 spawnPoint2 = new Vector3 (-70, Random.Range (-10.0f, 10.0f), Random.Range (-10.0f, 10.0f));
			Instantiate (Asteroids [Random.Range (0, Asteroids.Length)], gameObject.transform.position + spawnPoint2, Quaternion.identity);

			//spawn on Top
			Vector3 spawnPointT = new Vector3 (Random.Range (-10.0f, 10.0f), 70, Random.Range (-10.0f, 10.0f));
			Instantiate (Asteroids [Random.Range (0, Asteroids.Length)], gameObject.transform.position + spawnPointT, Quaternion.identity);

			//spawn on Bottom
			Vector3 spawnPointB = new Vector3 (Random.Range(-10.0f, 10.0f), -70, Random.Range (-10.0f, 10.0f));
			Instantiate (Asteroids [Random.Range (0, Asteroids.Length)], gameObject.transform.position + spawnPointB, Quaternion.identity);


			//if in densefield, spawn moar
			if(denseAsteroidField){
				//spawn on Right
				Vector3 spawnPoint3 = new Vector3 (70, Random.Range (-10.0f, 0f), Random.Range (-10.0f, 10.0f));
				Instantiate (Asteroids [Random.Range (0, Asteroids.Length)], gameObject.transform.position + spawnPoint3, Quaternion.identity);

				//Spawn of left
				Vector3 spawnPoint4 = new Vector3 (-70, Random.Range (-10.0f, 0f), Random.Range (-10.0f, 10.0f));
				Instantiate (Asteroids [Random.Range (0, Asteroids.Length)], gameObject.transform.position + spawnPoint4, Quaternion.identity);
				
			}
			yield return new WaitForSeconds (1.0f);
		}
	}
}
