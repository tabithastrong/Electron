using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Wire : MonoBehaviour
{
    public List<Vector3> points;

    LineRenderer lineRenderer;

    void OnValidate() {
        UpdatePoints();
    }

    public void UpdatePoints() {
        lineRenderer = GetComponent<LineRenderer>();
        
        lineRenderer.SetPositions(points.ToArray());
    }
}
