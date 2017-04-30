using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileActive : MonoBehaviour {
    public MissileLauncher enemy;
    public int count;
    int passes;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {

        passes++;
        if (other.CompareTag("Player") && passes >= count)
            enemy.Activate();
        transform.parent = null;
    }
}
