using System;
using UnityEngine;
using System.Collections.Generic;
using System.Net;

namespace RedTeam {

    public class SplinePathEditor : MonoBehaviour {

        public string splinePathAssetPath;
        public string newSplinePathName;

        public SplinePath path;

        public Color lineColor = Color.black;
        public Color nodeColor = Color.white;
        public Color handleColor = Color.green;

        public void AddNode() {

            SplineNode newNode;

            if(path.nodes != null && path.nodes.Count > 0) {

                SplineNode endNode = path.nodes[path.nodes.Count - 1];

                newNode = new SplineNode(
                    endNode.point + new Vector3(0f, 0f, 20f),
                    endNode.inHandle + new Vector3(0f, 0f, 20f),
                    endNode.point + (endNode.point - endNode.inHandle) + new Vector3(0f, 0f, 20f)
                );

            } else {

                if (path.nodes == null)
                    path.nodes = new List<SplineNode>();

                newNode = new SplineNode(
                    Vector3.zero, 
                    -10f * Vector3.one,
                    10f * Vector3.one
                );
            }

            path.nodes.Add(newNode);
        }

        public void RemoveNode() {

            if (path.nodes != null && path.nodes.Count > 0)
                path.nodes.RemoveAt(path.nodes.Count - 1);
        }

        void OnDrawGizmos() {

            if (path == null)
                return;

            Color prevColor = Gizmos.color;
            {
                Gizmos.color = nodeColor;

                for (int i = 0; i < path.nodes.Count; i++) {

                    Gizmos.DrawSphere(path.nodes[i].point, 1f);
                }

                Gizmos.color = lineColor;

                for (int i = 0; i < path.NumPoints - 1; i++) {

                    Gizmos.DrawLine(path.GetPoint(i), path.GetPoint(i + 1));
                }
            }
            Gizmos.color = prevColor;
        }

        void OnDrawGizmosSelected() {

            if (path == null)
                return;

            Color prevColor = Gizmos.color;
            {
                Gizmos.color = handleColor;

                for (int i = 0; i < path.nodes.Count; i++) {

                    if (i > 0) {

                        Gizmos.DrawSphere(path.nodes[i].inHandle, 0.6f);
                        Gizmos.DrawLine(path.nodes[i].point, path.nodes[i].inHandle);
                    }

                    if (i < path.nodes.Count - 1) {

                        Gizmos.DrawSphere(path.nodes[i].outHandle, 0.6f);
                        Gizmos.DrawLine(path.nodes[i].point, path.nodes[i].outHandle);
                    }
                }
            }
            Gizmos.color = prevColor;
        }
    }
}