using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capital_ArmorBreak : MonoBehaviour {

	private bool isDead;

	public GameObject trenchparts;

	//plate target rotation and position
	private Vector3 currAngle;
	private Vector3 currPos;
	public Vector3 targetAngle = new Vector3 (0f, 0f, 0f);
	public int targetX;
	public int targetY;
	public int targetZ;

	//Explosions
	public ParticleSystem exp1;
	public ParticleSystem exp2;
	public ParticleSystem exp3;

	private bool haveExploded = false;


	// Use this for initialization
	void Start () {
		currAngle = transform.eulerAngles;
		currPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//float the dead plate away from the ship
		if (isDead) {
			//Rotate
			currAngle = new Vector3(
				Mathf.LerpAngle(currAngle.x, targetAngle.x, Time.deltaTime),
				Mathf.LerpAngle(currAngle.y, targetAngle.y, Time.deltaTime),
				Mathf.LerpAngle(currAngle.z, targetAngle.z, Time.deltaTime));
			transform.eulerAngles = currAngle;
		}
	}

	public void breakArmor() {
		StartCoroutine (wait2secs ());
	}

	IEnumerator wait2secs() {
		yield return new WaitForSeconds (2);
		GameObject.Destroy(trenchparts);

		//float the plate away
		isDead = true;
		iTween.MoveTo (GameObject.Find ("Breakaway"), iTween.Hash ("x", targetX, "y", targetY, "z", targetZ, "islocal", true, "time", 10));

		//EXPLOSIONS
		if (!haveExploded) {
			exp1.Play (true);
			exp2.Play (true);
			exp3.Play (true);
			haveExploded = true;
		}
		
	}
}
