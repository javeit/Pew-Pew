using UnityEngine;
using UnityEditor;

namespace RedTeam {

    [CustomEditor(typeof(SplineEditor))]
    public class SplineEditorInspector : Editor {

        SplineEditor _target;

        Spline Spline {
            get {

                return _target.spline;

            } set {

                _target.spline = value;
            }
        }

        void DrawAddNodeButton() {

            bool prevEnabled = GUI.enabled;
            {
                GUI.enabled = prevEnabled && Spline.nodes != null;

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
                GUI.enabled = prevEnabled && Spline.nodes != null && Spline.nodes.Count > 2;

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
                int oldGranularity = Spline.granularity;
                
                Spline.granularity = EditorGUILayout.IntSlider("Granularity", Spline.granularity, 1, 100);

                if (oldGranularity != Spline.granularity) {

                    SceneView.RepaintAll();
                    Undo.RecordObject(_target, "Modified Spline Path Granularity");
                }
            }
            GUILayout.EndHorizontal();
        }

        void DrawCreateNewSplineButton() {

            _target.newSplineName = EditorGUILayout.TextField("New Spline Name", _target.newSplineName);
            _target.splineAssetPath = EditorGUILayout.TextField("Spline Asset Path", _target.splineAssetPath);

            if (GUILayout.Button("Locate Asset Path")) {

                string newPath = EditorUtility.OpenFolderPanel("Select the Spline Asset Folder", "Assets", "");

                if (!string.IsNullOrEmpty(newPath))
                    _target.splineAssetPath = newPath.Replace(Application.dataPath, "Assets");
            }

            if (GUILayout.Button("New Spline")) {

                Spline = ScriptableObject.CreateInstance<Spline>();

                _target.AddNode();
                _target.AddNode();

                Spline.granularity = 15;

                AssetDatabase.CreateAsset(Spline, _target.splineAssetPath + "/" + _target.newSplineName + ".asset");
            }
        }

        public override void OnInspectorGUI() {

            _target.spline = (Spline) EditorGUILayout.ObjectField("Spline", _target.spline, typeof(Spline), false);

            _target.lineColor = EditorGUILayout.ColorField("Line Color", _target.lineColor);
            _target.defaultNodeColor = EditorGUILayout.ColorField("Default Node Color", _target.defaultNodeColor);
            _target.startNodeColor = EditorGUILayout.ColorField("Start Node Color", _target.startNodeColor);
            _target.endNodeColor = EditorGUILayout.ColorField("End Node Color", _target.endNodeColor);
            _target.handleColor = EditorGUILayout.ColorField("Handle Color", _target.handleColor);

            _target.forceSmooth = EditorGUILayout.Toggle("Force Smooth", _target.forceSmooth);

            if (Spline == null) {

                EditorGUILayout.HelpBox("Assign a SplinePath object to the 'Path' field or click 'New Path' to begin editing", MessageType.Info);

            } else {

                DrawGranularitySlider();
                DrawAddNodeButton();
                DrawRemoveNodeButton();
            }

            DrawCreateNewSplineButton();
        }

        void DrawNodePositionHandles(out bool valueChanged) {

            valueChanged = false;

            if (Spline != null && Spline.nodes != null && Spline.nodes.Count > 0) {

                Vector3 oldPos;

                SplineNode currentNode;

                for (int i = 0; i < Spline.nodes.Count; i++) {

                    currentNode = Spline.nodes[i];

                    oldPos = currentNode.point;

                    currentNode.point = Handles.PositionHandle(currentNode.point, Quaternion.identity);

                    if (!currentNode.point.Equals(oldPos)) {

                        currentNode.inHandle += (currentNode.point - oldPos);
                        currentNode.outHandle += (currentNode.point - oldPos);

                        valueChanged = true;
                    }

                    if (i > 0) {

                        oldPos = currentNode.inHandle;
                        currentNode.inHandle = Handles.PositionHandle(currentNode.inHandle, Quaternion.identity);

                        if (!currentNode.inHandle.Equals(oldPos)) {

                            valueChanged = true;

                            if (_target.forceSmooth)
                                currentNode.outHandle = currentNode.point + (currentNode.point - currentNode.inHandle);
                        }
                    }

                    if (i < Spline.nodes.Count - 1) {

                        oldPos = currentNode.outHandle;
                        currentNode.outHandle = Handles.PositionHandle(currentNode.outHandle, Quaternion.identity);

                        if (!currentNode.outHandle.Equals(oldPos)) {

                            valueChanged = true;

                            if (_target.forceSmooth)
                                currentNode.inHandle = currentNode.point + (currentNode.point - currentNode.outHandle);
                        }
                    }
                }
            }
        }

        void OnSceneGUI() {

            DrawNodePositionHandles(out bool valueChanged);

            if (valueChanged) {

                Undo.RecordObject(_target, "Modified Spline Path Nodes");
                EditorUtility.SetDirty(Spline);
            }
        }

        void OnEnable() {

            _target = target as SplineEditor;
        }
    }
}