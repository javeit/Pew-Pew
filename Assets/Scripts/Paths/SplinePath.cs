using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedTeam {

    [Serializable]
    [CreateAssetMenu(fileName = "New Path", menuName = "RedTeam/SplinePath")]
    public class SplinePath : ScriptableObject {

        public List<SplineNode> nodes;

        public int granularity = 1;

        public int NumPoints {
            get {
                return (nodes.Count - 1) * granularity + 1;
            }
        }

        public Vector3 GetPoint(int index) {

            int nodeIndex = index / granularity;

            if(index % granularity == 0)
                return nodes[nodeIndex].point;

            float t = ((float)(index % granularity)) / ((float)granularity);

            return GetBezierPoint(nodes[nodeIndex].point, nodes[nodeIndex + 1].point, nodes[nodeIndex].outHandle, nodes[nodeIndex + 1].inHandle, t);
        }

        Vector3 GetBezierPoint(Vector3 startPoint, Vector3 endPoint, Vector3 outHandle, Vector3 inHandle, float t) {

            return Vector3.Lerp(Vector3.Lerp(Vector3.Lerp(startPoint, outHandle, t), Vector3.Lerp(outHandle, inHandle, t), t), Vector3.Lerp(Vector3.Lerp(outHandle, inHandle, t), Vector3.Lerp(inHandle, endPoint, t), t), t);
        }

        public void Init() {

            nodes = new List<SplineNode>(3);
            granularity = 1;
        }
    }

    [Serializable]
    public class SplineNode {

        public Vector3 point;
        public Vector3 inHandle;
        public Vector3 outHandle;

        public SplineNode(Vector3 point, Vector3 inHandle, Vector3 outHandle) {

            this.point = point;
            this.inHandle = inHandle;
            this.outHandle = outHandle;
        }
    }
}