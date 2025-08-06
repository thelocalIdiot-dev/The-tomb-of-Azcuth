using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightEmmiter : MonoBehaviour
{
    public Transform origin;
    public int maxReflections = 5;
    public float maxDistance = 100f;

    private LineRenderer lineRenderer;

    private Rceiver previousReceiver;

    public Rceiver receiver;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        CastLight();
    }

    void CastLight()
    {
        Vector2 direction = transform.up;
        Vector2 currentOrigin = origin.position;

        List<Vector3> points = new List<Vector3>();
        points.Add(currentOrigin);

        Rceiver currentReceiver = null;

        for (int i = 0; i < maxReflections; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(currentOrigin, direction, maxDistance);
            if (hit)
            {
                points.Add(hit.point);

                if (hit.collider.CompareTag("Mirror"))
                {
                    direction = Vector2.Reflect(direction, hit.normal);
                    currentOrigin = hit.point + direction * 0.01f;
                    continue;
                }
                else if (hit.collider.CompareTag("Receiver"))
                {
                    currentReceiver = hit.transform.GetComponent<Rceiver>();
                    currentReceiver?.OnLight.Invoke();
                    break;
                }
                else if (hit.collider.CompareTag("Split"))
                {

                }
                else
                {
                    break;
                }
            }
            else
            {
                points.Add(currentOrigin + direction * maxDistance);
                break;
            }
        }


        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());


        if (previousReceiver != null && previousReceiver != currentReceiver)
        {
            previousReceiver.OnNoLight.Invoke();
        }

        previousReceiver = currentReceiver;
    }


}
