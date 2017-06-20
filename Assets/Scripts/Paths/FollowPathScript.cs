using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathScript : MonoBehaviour {

	public float moveSpeed;

	void Update(){
		transform.Translate (new Vector3 (0, 0, 1) * moveSpeed * Time.deltaTime);
	}
}
