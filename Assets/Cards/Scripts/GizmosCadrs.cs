using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosCadrs : MonoBehaviour
{
    [SerializeField]
    private Vector3 GizScale = new Vector3(70, 1, 100);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, GizScale);
    }
}
