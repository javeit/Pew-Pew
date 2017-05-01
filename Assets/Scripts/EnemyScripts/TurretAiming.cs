using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAiming : MonoBehaviour {
    GameObject player;
    public GameObject turret;
	private float turnSpeedMult = 1.0f;
    //Camera camera;
    Component[] list;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
       // camera = Camera.main;
        list = turret.GetComponents<MonoBehaviour>();
    }

    // Update is called once per frame
    void Update() {
		iTween.LookUpdate(turret, iTween.Hash("looktarget", player.transform.position, "speed", 0.5f*turnSpeedMult));

    }

  

    void OnBecameInvisible()
    {
        foreach (MonoBehaviour script in list)
        {
            script.enabled = false;
        }
    }

    void OnBecameVisible()
    {

        foreach (MonoBehaviour script in list)
        {
            script.enabled = true;
        }
    }
}
