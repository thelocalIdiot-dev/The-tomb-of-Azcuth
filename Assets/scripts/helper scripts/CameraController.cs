using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Focus points")]
    public focusPoints[] FocusPoints;
    [Header("references")]
    public Transform CameraPos;
    public CinemachineVirtualCamera camFov;
    [Header("Player")]
    public Vector3 camOffset;
    public float BaseFov;
    public float targetFov;
    [Header("Camera")]
    public Vector3 DesiredCamPosition;

    public static CameraController instance;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        //-----Camera Logic-----//
        if(playerMovement.instance != null)
        {
            Vector3 playerPosition = playerMovement.instance.transform.position;
            bool focused = false;

            foreach (focusPoints fp in FocusPoints)
            {
                float distance = Vector2.Distance(playerPosition, fp.focusPoint.position);
                if (distance < fp.radius)
                {
                    DesiredCamPosition = fp.focusPoint.position + new Vector3(0, 0, -10);
                    targetFov = fp.FieldOfView;
                    focused = true;
                    break;
                }
            }

            if (!focused)
            {
                {
                    DesiredCamPosition = playerPosition + camOffset;
                    targetFov = BaseFov;
                }               
            }

            CameraPos.position = DesiredCamPosition;
            camFov.m_Lens.OrthographicSize = Mathf.Lerp(camFov.m_Lens.OrthographicSize, targetFov, 0.25f);
        }
        
    }

    private void OnDrawGizmos()
    {
        foreach (focusPoints fp in FocusPoints)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(fp.focusPoint.position, fp.radius);
        }
    }
}

[System.Serializable]
public class focusPoints
{
    public Transform focusPoint;
    public float radius;
    public float FieldOfView;
}

