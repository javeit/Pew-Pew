using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel2 : MonoBehaviour {

	void OnTriggerEnter(Collider end) {
		if (end.gameObject.tag == "Player") {
			SceneManager.LoadScene ("Level2", LoadSceneMode.Single);
		}
	}
}
