using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileActive : MonoBehaviour {
    public Missile enemy;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            enemy.Activate();
        transform.parent = null;
    }
}
