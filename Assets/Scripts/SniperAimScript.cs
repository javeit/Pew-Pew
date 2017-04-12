using UnityEngine;
using System.Collections;

public class SniperAimScript : MonoBehaviour
{
	private Transform target;

	void Start (){
		target = GameObject.FindGameObjectWithTag ("SniperTarget").transform;
	}
	
	void Update (){
		transform.LookAt (target);
	}
}

