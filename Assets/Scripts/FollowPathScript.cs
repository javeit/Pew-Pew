using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathScript : MonoBehaviour {

	public float pathTime1;
	public float pathTime2;
	public PlayerController player;

	private float time;

	void Start () {
		time = 2;
		player = GetComponentInChildren<PlayerController> ();
	}

	void Update(){
		time -= Time.deltaTime;

		if (time <= 0) {
			if (player.transform.localPosition.x < 0) {
				iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("PlayerPath2"), "time", pathTime2, "easetype", iTween.EaseType.linear, "orientToPath",true));
				time = pathTime2;
			} else {
				iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("PlayerPath1"), "time", pathTime1, "easetype", iTween.EaseType.linear, "orientToPath",true));
				time = pathTime1;
			}
		}
	}
}
