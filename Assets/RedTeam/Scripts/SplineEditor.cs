using System;
using UnityEngine;
using System.Collections.Generic;

namespace RedTeam {

    public class SplineEditor : MonoBehaviour {

        public string splineAssetPath;
        public string newSplineName;

        public Spline spline;

        public Color lineColor = Color.black;
        public Color defaultNodeColor = Color.white;
        public Color handleColor = Color.green;

        public Color startNodeColor = Color.green;
        public Color endNodeColor = Color.red;

        public bool forceSmooth;

        public void AddNode() {

            SplineNode newNode;

            if(spline.nodes != null) {

                if(spline.nodes.Count > 1) {

                    SplineNode lastNode = spline.nodes[spline.nodes.Count - 1];
                    SplineNode nextToLastNode = spline.nodes[spline.nodes.Count - 2];

                    newNode = new SplineNode(
                        lastNode.point + (lastNode.point - nextToLastNode.point),
                        lastNode.inHandle + (lastNode.point - nextToLastNode.point),
                        lastNode.point + (lastNode.point - lastNode.inHandle) + (lastNode.point - nextToLastNode.point)
                    );

                } else if(spline.nodes.Count > 0) {

                    SplineNode lastNode = spline.nodes[spline.nodes.Count - 1];

                    newNode = new SplineNode(
                        lastNode.point + new Vector3(0f, 0f, 20f),
                        lastNode.inHandle + new Vector3(0f, 0f, 20f),
                        lastNode.point + (lastNode.point - lastNode.inHandle) + new Vector3(0f, 0f, 20f)
                    );

                } else {

                    newNode = new SplineNode(
                        Vector3.zero,
                        -10f * Vector3.one,
                        10f * Vector3.one
                    );
                }

            } else {

                spline.nodes = new List<SplineNode>();

                newNode = new SplineNode(
                    Vector3.zero, 
                    -10f * Vector3.one,
                    10f * Vector3.one
                );
            }

            spline.nodes.Add(newNode);
        }

        public void RemoveNode() {

            if (spline.nodes != null && spline.nodes.Count > 0)
                spline.nodes.RemoveAt(spline.nodes.Count - 1);
        }

        void OnDrawGizmos() {

            if (spline == null || spline.nodes == null || spline.nodes.Count == 0)
                return;

            Color prevColor = Gizmos.color;
            {
                if (spline.nodes.Count > 1) {

                    // start node
                    {
                        Gizmos.color = startNodeColor;
                        Gizmos.DrawSphere(spline.nodes[0].point, 1f);
                    }

                    // end node
                    {
                        Gizmos.color = endNodeColor;
                        Gizmos.DrawSphere(spline.nodes[spline.nodes.Count - 1].point, 1f);
                    }
                }

                Gizmos.color = defaultNodeColor;

                for (int i = 1; i < spline.nodes.Count - 1; i++) {

                    Gizmos.DrawSphere(spline.nodes[i].point, 1f);
                }

                Gizmos.color = lineColor;

                for (int i = 0; i < spline.NumPoints - 1; i++) {

                    Gizmos.DrawLine(spline.GetPoint(i), spline.GetPoint(i + 1));
                }
            }
            Gizmos.color = prevColor;
        }

        void OnDrawGizmosSelected() {

            if (spline == null)
                return;

            Color prevColor = Gizmos.color;
            {
                Gizmos.color = handleColor;

                for (int i = 0; i < spline.nodes.Count; i++) {

                    if (i > 0) {

                        Gizmos.DrawSphere(spline.nodes[i].inHandle, 0.6f);
                        Gizmos.DrawLine(spline.nodes[i].point, spline.nodes[i].inHandle);
                    }

                    if (i < spline.nodes.Count - 1) {

                        Gizmos.DrawSphere(spline.nodes[i].outHandle, 0.6f);
                        Gizmos.DrawLine(spline.nodes[i].point, spline.nodes[i].outHandle);
                    }
                }
            }
            Gizmos.color = prevColor;
        }
    }
}