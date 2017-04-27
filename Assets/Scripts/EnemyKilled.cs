using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilled : MonoBehaviour {
	public bool dropPowerUp;

	public GameObject powerDrop;
	
	// Update is called once per frame
	void Update () {
		
	}
	public void afterDeath() {
		StartCoroutine (wait2secs ());
		if (dropPowerUp) {
			GameObject powerCoin = Instantiate (powerDrop, gameObject.transform);
			powerCoin.transform.localPosition = new Vector3(0f,0f,0f);
		}
	}

	IEnumerator wait2secs() {
		yield return new WaitForSeconds (2);
		//kill the entire ship prefab
		Destroy(gameObject);
	}

}
