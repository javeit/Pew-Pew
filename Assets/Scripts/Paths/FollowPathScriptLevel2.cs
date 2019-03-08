using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathScriptLevel2 : MonoBehaviour {

	public float pathTime;

	void Start () {
        // TODO: Replace iTween solutions
        //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("PlayerPath"), "time", pathTime, "easetype", iTween.EaseType.linear, "orientToPath",true));
    }
}
