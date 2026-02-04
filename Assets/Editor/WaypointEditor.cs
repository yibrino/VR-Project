using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class WaypointEditor
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmos(Waypoint waypoint, GizmoType gizmoType)
    {
        // Color based on selection
        if ((gizmoType & GizmoType.Selected) != 0)
            Gizmos.color = Color.blue;
        else
            Gizmos.color = Color.blue * 0.5f;

        // Draw waypoint sphere
        Gizmos.DrawSphere(waypoint.transform.position, 0.1f);

        // Draw waypoint width line
        Gizmos.color = Color.white;
        Gizmos.DrawLine(
            waypoint.transform.position + (waypoint.transform.right * waypoint.waypointWidth / 2f),
            waypoint.transform.position - (waypoint.transform.right * waypoint.waypointWidth / 2f)
        );

        // Now draw a line from previous to next waypoint (if you have references set up)
        if (waypoint.previousWaypoint != null)
        {
            Gizmos.DrawLine(waypoint.previousWaypoint.transform.position, waypoint.transform.position);
        }

        if (waypoint.nextWaypoint != null)
        {
            Gizmos.DrawLine(waypoint.transform.position, waypoint.nextWaypoint.transform.position);
        }
    }
}
