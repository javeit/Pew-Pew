using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Wave{
	public float timeToWave;
	public int numberOfEnemies;
}

public class GruntWaveData : MonoBehaviour {

	public Wave[] waves;

}