using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAiming : MonoBehaviour {
    GameObject player;
    public GameObject turret;
    //Camera camera;
    Component[] list;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
       // camera = Camera.main;
        list = turret.GetComponents<MonoBehaviour>();
    }

    // Update is called once per frame
    void Update() {
        iTween.LookUpdate(turret, iTween.Hash("looktarget", player.transform.position, "speed", .5f));
       /* Vector3 point = camera.WorldToViewportPoint(transform.position);
        if (point.z > 0 && point.x > 0 && point.x < 1 && point.y > 0 && point.y < 1)
        {
            print("henlo");
        }*/

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
