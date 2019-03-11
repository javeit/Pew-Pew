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
	public GameObject[] headShots;
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
     public void SetDialogueOut(int i)
     {
			setActive(i);
            t = 0;
            startPosition = transform.GetComponent<RectTransform>().anchoredPosition;
            timeToReachTarget = 1f;
            target = new Vector3(dialogueRightX,startPosition.y,startPosition.z); 
     }
	 public void SetDialogueIn(float f)
     {
		StartCoroutine(SDI(f));
     }
	 IEnumerator SDI(float f)
	 {
		yield return new WaitForSeconds(f);
        t = 0;
        startPosition = transform.GetComponent<RectTransform>().anchoredPosition;
        timeToReachTarget = 1f;
        target = new Vector3(dialogueLeftX,startPosition.y,startPosition.z); 
	 }
	 void setActive(int i)
	 {
		 if(i == 0)
		 {
			 headShots[0].SetActive(true);
			 headShots[1].SetActive(false);
		 }
		 else if(i == 01)
		 {
			 headShots[0].SetActive(false);
			 headShots[1].SetActive(true);
		 }
	 }
}
