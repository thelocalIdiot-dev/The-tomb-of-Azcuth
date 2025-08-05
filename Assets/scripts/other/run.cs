using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;
    public float waitTimeAtPoint = 1f;

    private int currentIndex = 0;
    private float waitTimer = 0f;

    void Update()
    {
        if (waypoints.Length == 0) return;

        Transform target = waypoints[currentIndex];
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTimeAtPoint)
            {
                currentIndex = (currentIndex + 1) % waypoints.Length;
                waitTimer = 0f;
            }
        }
    }

    // Visualización en el editor
    void OnDrawGizmos()
    {

        Gizmos.color = Color.green;
        if (waypoints != null && waypoints.Length > 1)
        {
            for (int i = 0; i < waypoints.Length; i++)
            {
                Gizmos.DrawSphere(waypoints[i].position, 0.1f);
                Gizmos.DrawLine(waypoints[i].position, waypoints[(i + 1) % waypoints.Length].position);
            }
        }
    }
}
