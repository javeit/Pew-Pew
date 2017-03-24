using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathScript : MonoBehaviour {

	public float pathTime;

	void Start () {
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("PlayerPath"), "time", pathTime, "easetype", iTween.EaseType.easeInOutSine, "orientToPath",true, "lookTime", 0.2, "looptype", iTween.LoopType.loop, "delay", 0));
	}
}
