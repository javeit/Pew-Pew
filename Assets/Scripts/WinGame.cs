using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour {

	public GameObject Core;

	//when capital ship core dies, go to game over screen
	void Update (){
		if (!Core) {
			StartCoroutine(wait5secs());
		}
	}
	IEnumerator wait5secs() {
		yield return new WaitForSeconds (5);
		//load game over screen
		SceneManager.LoadScene ("Main Menu", LoadSceneMode.Single);
	}


}
