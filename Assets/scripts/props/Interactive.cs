using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactive : MonoBehaviour
{
    public GameObject interactText;

    public UnityEvent Event;

    public float radius;


    private void Update()
    {
        Vector3 playerPosition = playerMovement.instance.transform.position;
        float distance = Vector2.Distance(playerPosition, transform.position);

        if (distance < radius)
        {
            interactText.SetActive(true);
            interactText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {              
                Event.Invoke();
                
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
