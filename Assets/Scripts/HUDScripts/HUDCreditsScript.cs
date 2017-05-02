using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//////////////////
//This code is adapted from an answer on Unity forums
//about moving objects over time. Said forum can
//be found at: http://answers.unity3d.com/questions/296347/move-transform-to-target-in-x-seconds.html
//////////////////
public class HUDCreditsScript : MonoBehaviour {
	
	float t;
	Vector3 startPosition;
	Vector3 target;
	float timeToReachTarget = 0;
	float timeTrack;
	bool moving = false;
	// Use this for initialization
	void Start () {
		startPosition = target = transform.GetComponent<RectTransform>().anchoredPosition;
	}
	
	// Update is called once per frame
	void Update() 
     {
             t += Time.deltaTime/timeToReachTarget;
			 timeTrack += Time.deltaTime;
             transform.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(startPosition, target, t);
			 if(timeTrack > timeToReachTarget && moving)
			 {
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.Confined;
				SceneManager.LoadScene ("Main Menu",LoadSceneMode.Single);
			 }
     }
     public void SetDestination(Vector3 destination, float time)
     {
            t = 0;
			timeTrack = 0;
            startPosition = transform.GetComponent<RectTransform>().anchoredPosition;
            timeToReachTarget = time;
            target = destination; 
     }
	 public void StartRoll()
	 {
		 SetDestination(new Vector3(startPosition.x,2000,startPosition.z),15);
		 moving = true;
	 }
}
