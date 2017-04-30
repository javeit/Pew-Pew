using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathScriptLevel3 : MonoBehaviour {

	public float startPathTime;
	public float trenchRunTime;
	public float toCoreTime;
	public float strafeSpeed;
	public Camera mainCamera;
	public Camera pulledOut;
	public EnemyPartHealth boss;

	private float time;
	private bool inTrench;
	private bool onStrafe;
	private bool toCore;

	void Start () {
		pulledOut.enabled = false;
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Start Path"), "time", startPathTime, "orientToPath",true, "easetype", iTween.EaseType.linear));
		time = trenchRunTime + toCoreTime + startPathTime;
		inTrench = false;
		onStrafe = false;
		toCore = false;
	}

	void Update () {
		if (time < toCoreTime + trenchRunTime + 0.01 && !inTrench) {
			iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Trench Run"), "time", trenchRunTime, "orientToPath", true, "easetype", iTween.EaseType.linear));
			inTrench = true;
		}
		if (time < toCoreTime + 0.01 && !toCore && boss.pathChange) {
			toCore = true;
			iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Path to Core"), "time", toCoreTime, "easetype", iTween.EaseType.linear, "orientToPath", true));
		}
		if (time < 1 && !onStrafe && toCore) {
			iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("Strafing the Core"), "time", strafeSpeed, "looptype", iTween.LoopType.pingPong, "easetype", iTween.EaseType.linear));
			onStrafe = true;
			transform.rotation = Quaternion.Euler (new Vector3 (90, 180, 90));
		}
		time -= Time.deltaTime;
		Debug.Log (time);

		if (boss.pathChange && !onStrafe) {
			pulledOut.enabled = true;
			mainCamera.enabled = false;
		} else {
			pulledOut.enabled = false;
			mainCamera.enabled = true;
		}
	}
}