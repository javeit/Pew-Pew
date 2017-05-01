using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ActiveCollider : MonoBehaviour {

	public int count = 0;

	private int passes = 0;

	public EnemyBehavior enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player") && passes >= count) {
			passes++;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Player") && passes >= count) {
			enemy.Activate ();
			transform.parent = null;
		}
	}
}
