using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathScriptLevel3 : MonoBehaviour {

	public float trenchRunTime;
	public float resetPathTime;
	public Camera mainCamera;
	public Camera pulledOut;

	private float time;
	private bool inTrench;
	private bool onReset;
	private bool bossExposed;

	void Start () {
		pulledOut.enabled = false;
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Trench Run"), "time", trenchRunTime, "easetype", iTween.EaseType.linear, "orientToPath",true));
		inTrench = true;
		onReset = false;
		bossExposed = false;
		time = trenchRunTime;
	}

	void Update () {
		if (inTrench && time < 1) {
			pulledOut.enabled = true;
			mainCamera.enabled = false;
			iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Trench Reset"), "time", resetPathTime, "easetype", iTween.EaseType.linear, "orientToPath", true));
			inTrench = false;
			onReset = true;
			time = resetPathTime;
		} else if (onReset && time < 1) {
			pulledOut.enabled = false;
			mainCamera.enabled = true;
			iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Trench Run"), "time", trenchRunTime, "easetype", iTween.EaseType.linear, "orientToPath", true));
			inTrench = true;
			onReset = false;
			time = trenchRunTime;
		}
		time -= Time.deltaTime;
		//Debug.Log (time);
	}
}