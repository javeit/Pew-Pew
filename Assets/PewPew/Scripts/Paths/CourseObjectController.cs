using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    /// <summary>
    /// The controller for the object that follows the course, 
    /// which contains the player and the main camera (moving both along the course with it)
    /// </summary>
    public class CourseObjectController : GameEventListener {

        const float Epsilon = 0.0001f;

        public PlayerController player;

        public float moveSpeed;

        public Transform rotationObject;

        Coroutine followCourseCorountine;

        IEnumerator FollowCourse(CourseSegment segment) {

            Spline path = segment.path;
            int i = 0;

            Vector3 moveVector;

            // rotation lerping variables
            float segmentLength;
            Quaternion startRotation;
            Quaternion endRotation;
            float startTime;

            while (i < path.NumPoints) {

                moveVector = path.GetPoint(i) - transform.position;

                // rotation lerping variables
                segmentLength = moveVector.magnitude;
                startRotation = rotationObject.rotation;
                endRotation = Quaternion.LookRotation(moveVector);
                startTime = Time.time;

                while (moveVector.magnitude > moveSpeed * Time.deltaTime) {

                    // to halt the coroutine while paused
                    while (_paused)
                        yield return null;

                    transform.Translate(moveVector.normalized * moveSpeed * Time.deltaTime);

                    // lerp the rotation based on the rotation at the beginning of this segment (between two points)
                    // and the direction facing the next point based on the percentage of the way to the next point
                    // the ship has traveled
                    rotationObject.rotation = Quaternion.Lerp(startRotation, endRotation, (Time.time - startTime) / (segmentLength / moveSpeed));

                    yield return null;

                    moveVector = path.GetPoint(i) - transform.position;
                }

                i++;
            }

            CourseSegment nextSegment = segment.GetNextCourseSegment();

            if (nextSegment != null)
                yield return FollowCourse(nextSegment);
            else
                EventManager.TriggerBroadcast("StopGame");
        }

        protected override void OnStartGame() {

            base.OnStartGame();

            CourseSegment startingSegment = EventManager.Request<CourseSegment>("StartingSegment");

            followCourseCorountine = StartCoroutine(FollowCourse(startingSegment));
        }

        protected override void OnStopGame() {

            base.OnStopGame();

            StopCoroutine(followCourseCorountine);
        }
    }
}