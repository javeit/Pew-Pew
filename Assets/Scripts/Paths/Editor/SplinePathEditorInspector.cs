using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RedTeam {

    [CustomEditor(typeof(SplinePathEditor))]
    public class SplinePathEditorInspector : Editor {

        SplinePathEditor _target;

        public override void OnInspectorGUI() {

            DrawDefaultInspector();

            if (_target.path == null) {

                EditorGUILayout.HelpBox("Assign a SplinePath object to the 'Path' field or click 'New Path' to begin editing", MessageType.Info);

            } else {

                DrawGranularitySlider();
                DrawAddNodeButton();
                DrawRemoveNodeButton();
            }

            DrawCreatNewPathButton();
        }

        void DrawAddNodeButton() {

            bool prevEnabled = GUI.enabled;
            {
                GUI.enabled = prevEnabled && _target.path.nodes != null;

                if (GUILayout.Button("Add Node")) {

                    _target.AddNode();
                    SceneView.RepaintAll();

                    Undo.RecordObject(_target, "Added Spline Path Node");
                }
            }
            GUI.enabled = prevEnabled;
        }

        void DrawRemoveNodeButton() {

            bool prevEnabled = GUI.enabled;
            {
                GUI.enabled = prevEnabled && _target.path.nodes != null && _target.path.nodes.Count > 2;

                if (GUILayout.Button("Remove Node")) {

                    _target.RemoveNode();
                    SceneView.RepaintAll();

                    Undo.RecordObject(_target, "Removed Spline Path Node");
                }
            }
            GUI.enabled = prevEnabled;
        }

        void DrawGranularitySlider() {

            GUILayout.BeginHorizontal();
            {
                int oldGranularity = _target.path.granularity;
                
                _target.path.granularity = EditorGUILayout.IntSlider("Granularity", _target.path.granularity, 1, 25);

                if (oldGranularity != _target.path.granularity) {

                    SceneView.RepaintAll();
                    Undo.RecordObject(_target, "Modified Spline Path Granularity");
                }
            }
            GUILayout.EndHorizontal();
        }

        void DrawCreatNewPathButton() {

            if (GUILayout.Button("New Path")) {

                _target.path = ScriptableObject.CreateInstance<SplinePath>();

                _target.AddNode();
                _target.AddNode();

                _target.path.granularity = 15;

                AssetDatabase.CreateAsset(_target.path, _target.splinePathAssetPath + "/" + _target.newSplinePathName + ".asset");
            }
        }

        void OnSceneGUI() {

            if (_target.path != null && _target.path.nodes != null && _target.path.nodes.Count > 0) {

                Vector3 oldPos;
                bool recordUndo = false;

                for (int i = 0; i < _target.path.nodes.Count; i++) {

                    oldPos = _target.path.nodes[i].point;

                    _target.path.nodes[i].point = Handles.PositionHandle(_target.path.nodes[i].point, Quaternion.identity);

                    if (!_target.path.nodes[i].point.Equals(oldPos)) {

                        _target.path.nodes[i].inHandle += (_target.path.nodes[i].point - oldPos);
                        _target.path.nodes[i].outHandle += (_target.path.nodes[i].point - oldPos);

                        recordUndo = true;

                    } else {

                        if (i > 0) {

                            oldPos = _target.path.nodes[i].inHandle;
                            _target.path.nodes[i].inHandle = Handles.PositionHandle(_target.path.nodes[i].inHandle, Quaternion.identity);

                            if (!_target.path.nodes[i].inHandle.Equals(oldPos))
                                recordUndo = true;
                        }

                        if (i < _target.path.nodes.Count - 1) {

                            oldPos = _target.path.nodes[i].outHandle;
                            _target.path.nodes[i].outHandle = Handles.PositionHandle(_target.path.nodes[i].outHandle, Quaternion.identity);

                            if (!_target.path.nodes[i].outHandle.Equals(oldPos))
                                recordUndo = true;
                        }
                    }
                }

                if(recordUndo)
                    Undo.RecordObject(_target, "Modified Spline Path Nodes");
            }
        }

        void OnEnable() {

            _target = target as SplinePathEditor;
        }
    }
}