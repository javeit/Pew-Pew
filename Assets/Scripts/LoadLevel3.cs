using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel3 : MonoBehaviour {

	void OnTriggerEnter(Collider end) {
		if (end.gameObject.tag == "Player") {
			SceneManager.LoadScene ("Level3", LoadSceneMode.Single);
		}
	}
}
