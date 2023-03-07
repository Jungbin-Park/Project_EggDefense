using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoView : MonoBehaviour
{
    public Color color = Color.blue;
    public float radius = 0.5f;

    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
