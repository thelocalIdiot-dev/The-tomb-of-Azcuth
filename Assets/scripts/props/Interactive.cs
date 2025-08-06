using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactive : MonoBehaviour
{
    public GameObject interactText;

    public UnityEvent Event;

    public float radius;
    private GameObject player;

    private void Start()
    {



        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        Vector3 playerPosition = player.transform.position;
        float distance = Vector2.Distance(playerPosition, transform.position);

        if (distance < radius)
        {
            interactText.SetActive(true);
            interactText.SetActive(true);
            if (gameObject.name == "mirror")
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
                interactText.transform.position = screenPos + new Vector3(200, -50, 0);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Interacción!");
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
