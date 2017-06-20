using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntSpawner : MonoBehaviour {

	Wave[] waves;
	int index;
	float time;

	ObjectPoolerScript gruntPool;
	Transform[] waypoints;
	Transform pathObject;

	void Start () {
		waves = GameObject.Find ("WaveData").GetComponent<GruntWaveData> ().waves;
		index = 0;
		time = 0;
		gruntPool = GameObject.Find ("ObjectPool").GetComponent<GruntPoolerScript> ();
		waypoints = GameObject.Find ("Enemy Waypoints").GetComponentsInChildren<Transform> ();
		pathObject = GameObject.Find ("path object").transform;
	}

	void Update () {

		if (time >= waves [index].timeToWave) {
			SpawnEnemies (waves [index].numberOfEnemies);
			index++;
			if(index == waves.Length)
				Destroy (gameObject);
		}

		time += Time.deltaTime;
	}

	/// <summary>
	/// Calls SpawnEnemy the number of times specified by the paramater numEnemies
	/// </summary>
	/// <param name="numEnemies">Number enemies.</param>
	void SpawnEnemies(int numEnemies){
		for (int i = 0; i < numEnemies; i++) {
			SpawnEnemy ();
		}
	}

	/// <summary>
	/// Retrieves a grunt enemy from the object pool, resets it's values, and sets it in the world
	/// </summary>
	void SpawnEnemy(){
		GameObject go = gruntPool.GetPooledObject ();
		EnemyBehavior grunt = go.GetComponent<EnemyBehavior> ();
		grunt.Reset ();
		grunt.points = new Transform[2];
		int index = Random.Range (0, waypoints.Length);
		grunt.points [0] = waypoints [index];
		int index2 = Random.Range (0, waypoints.Length);
		if (index2 == index)
			index2 = (index + 1) % waypoints.Length;
		grunt.points [1] = waypoints [index2];

		go.transform.parent = pathObject;
		go.transform.localPosition = new Vector3 (Random.Range (-30.0f, 30.0f), 30, 30);
		Transform[] objects = go.GetComponentsInChildren<Transform> (true);
		foreach (Transform obj in objects) {
			obj.gameObject.SetActive (true);
		}
	}
}
