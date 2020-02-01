using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Wire))]
public class WireEditor : Editor
{
    void OnEnable() {
        
    }

    public void OnSceneGUI() {
        Wire w = (target as Wire);
        Rect clickArea = EditorGUILayout.GetControlRect();
        Event current = Event.current;
        
        if(clickArea.Contains(Input.mousePosition) &&  current.type == EventType.KeyDown && current.keyCode == KeyCode.P) {
            Vector2 point = Camera.current.ScreenToWorldPoint(current.mousePosition);
            w.points.Add(w.transform.InverseTransformPoint(point));
            Undo.RecordObject(w, "Added wire position");
        }


        EditorGUI.BeginChangeCheck();

        for(int i = 0; i < w.points.Count; i++) {
            Vector3 point = Handles.PositionHandle(w.transform.TransformPoint(w.points[i]), Quaternion.identity);
            w.points[i] = w.transform.InverseTransformPoint(point);
        }

        if(EditorGUI.EndChangeCheck()) {
            Undo.RecordObject(w, "Updated wire positions");
        }

        w.UpdatePoints();
    }
}
