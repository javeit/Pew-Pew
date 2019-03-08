using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    public class FollowPathScript : MonoBehaviour {

        public float pathTime1;
        public float secondPathTime;
        public float leftPathStartTime;
        public float leftPathLoopTime;
        public float leftPathEndTime;
        public int numLoopsLeft;
        public float rightPathStartTime;
        public float rightPathLoop1Time;
        public float rightPathLoop2Time;
        public float rightPathEndTime;
        public float numLoopsRight;
        public float numLoopsRight2;
        public PlayerController player;

        float time;
        bool onSecondPath;
        bool onLeftPath;
        bool onRightPath;
        bool onEndPath;

        void Update() {

            time -= Time.deltaTime;

            if ((time < secondPathTime + 1) && !onSecondPath) {

                if (player.transform.localPosition.x > 0) {

                    // TODO: Replace iTween solutions
                    //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("RightPathStart"), "time", rightPathStartTime, "easetype", iTween.EaseType.linear, "orientToPath", true));
                    onRightPath = true;

                } else {

                    // TODO: Replace iTween solutions
                    //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("LeftPathStart"), "time", leftPathStartTime, "easetype", iTween.EaseType.linear, "orientToPath", true));
                    onLeftPath = true;
                }

                onSecondPath = true;

            } else if (onLeftPath && !onEndPath) {

                if (time < leftPathEndTime + 1) {

                    // TODO: Replace iTween solutions
                    //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("LeftPathEnd"), "time", leftPathEndTime, "easetype", iTween.EaseType.linear, "orientToPath", true));
                    onEndPath = true;

                } else if (time < (leftPathLoopTime * numLoopsLeft) + leftPathEndTime + 1) {

                    // TODO: Replace iTween solutions
                    //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("LeftPathLoop"), "time", leftPathLoopTime, "easetype", iTween.EaseType.linear, "orientToPath", true));
                    numLoopsLeft--;
                }

            } else if (onRightPath && !onEndPath) {

                if (time < rightPathEndTime + 1) {

                    // TODO: Replace iTween solutions
                    //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("RightPathEnd"), "time", rightPathEndTime, "easetype", iTween.EaseType.linear, "orientToPath", true));
                    onEndPath = true;

                } else if ((time < (rightPathLoop1Time * numLoopsRight) + (rightPathLoop2Time * numLoopsRight2) + rightPathEndTime + 1) && (time > (rightPathLoop2Time * numLoopsRight2) + rightPathEndTime + 1)) {

                    // TODO: Replace iTween solutions
                    //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("RightPathLoop1"), "time", rightPathLoop1Time, "easetype", iTween.EaseType.linear, "orientToPath", true));
                    numLoopsRight--;

                } else if (time < (rightPathLoop2Time * numLoopsRight2) + rightPathEndTime + 1) {

                    // TODO: Replace iTween solutions
                    //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("RightPathLoop2"), "time", rightPathLoop2Time, "easetype", iTween.EaseType.linear, "orientToPath", true));
                    numLoopsRight2--;
                }
            }

            //Debug.Log ("Time: " + time);
        }

        void Start() {

            time = pathTime1 + secondPathTime;
            // TODO: Replace iTween solutions
            //iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("PlayerPath1"), "time", pathTime1, "easetype", iTween.EaseType.linear, "orientToPath", true));
            player = GetComponentInChildren<PlayerController>();
            onSecondPath = false;
            onLeftPath = false;
            onRightPath = false;
            onEndPath = false;
        }
    }
}