using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDialogueScript : MonoBehaviour {

	// Use this for initialization
	float t;
	Vector3 startPosition;
	Vector3 target;
	float timeToReachTarget;
	private float dialogueRightX = 481;
	private float dialogueLeftX = 338;
	// Use this for initialization
	void Start () {
		startPosition = target = transform.GetComponent<RectTransform>().anchoredPosition;
	}
	
	// Update is called once per frame
	void Update() 
     {
             t += Time.deltaTime/timeToReachTarget;
             transform.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(startPosition, target, t);
     }
     public void SetDialogueOut()
     {
            t = 0;
            startPosition = transform.GetComponent<RectTransform>().anchoredPosition;
            timeToReachTarget = 4f;
            target = new Vector3(dialogueRightX,startPosition.y,startPosition.z); 
     }
	 public void SetDialogueIn(Vector3 destination, float time)
     {
            t = 0;
            startPosition = transform.GetComponent<RectTransform>().anchoredPosition;
            timeToReachTarget = 4f;
            target = new Vector3(dialogueLeftX,startPosition.y,startPosition.z); 
     }
}
