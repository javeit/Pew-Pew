using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathScript : MonoBehaviour {

	public float pathTime1;
	public float pathTime2;
	public PlayerController player;

	private float time;
	private bool restart;
	private bool onSecondPath;

	void Start () {
		time = pathTime1 + pathTime2;
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("PlayerPath1"), "time", pathTime1, "easetype", iTween.EaseType.linear, "orientToPath",true));
		player = GetComponentInChildren<PlayerController> ();
		restart = false;
		onSecondPath = false;
	}

	void Update(){
		if (restart) {
			if (time <= 0) {
				iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("PlayerPath1"), "time", pathTime1, "easetype", iTween.EaseType.linear, "orientToPath",true));
				restart = false;
				time = pathTime1 + pathTime2;
			}
		}else{
			if ((time < pathTime2 + 1) && !onSecondPath) {
				if (player.transform.localPosition.x > 0) {
					iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("PlayerPath2"), "time", pathTime2, "easetype", iTween.EaseType.linear, "orientToPath", true, "lookTime", 5));
				} else {
					iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("PlayerPath3"), "time", pathTime2, "easetype", iTween.EaseType.linear, "orientToPath", true));
				}
				onSecondPath = true;
			}
			if (time <= 0) {
				iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("ResetPath"), "time", 2, "easetype", iTween.EaseType.linear, "orientToPath", true));
				time = 2;
				restart = true;
				onSecondPath = false;
			}
			//Debug.Log ("Time: " + time);
		}
		time -= Time.deltaTime;
	}
}
