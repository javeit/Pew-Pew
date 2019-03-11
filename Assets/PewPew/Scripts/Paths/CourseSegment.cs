using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam.PewPew {

    [Serializable]
    [CreateAssetMenu(fileName = "New Course Segment", menuName = "RedTeam/PewPew/CourseSegment/CourseSegment")]
    public class CourseSegment : ScriptableObject {

        [SerializeField]
        CourseSegment _nextSegment;

        public CourseSegment GetNextCourseSegment() {

            return _nextSegment;
        }

        public Spline path;
    }
}