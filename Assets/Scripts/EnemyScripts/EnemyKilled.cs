using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilled : MonoBehaviour {

	void Start(){
		
	}
	// Update is called once per frame
	void Update () {
		
	}
	public void afterDeath() {
		StartCoroutine (wait2secs ());
	}

	IEnumerator wait2secs() {
		yield return new WaitForSeconds (2);
		//kill the entire ship prefab
		gameObject.SetActive(false);
	}

}
