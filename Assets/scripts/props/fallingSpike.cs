using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;

using UnityEngine;

public class fallingSpike : MonoBehaviour
{
    public Transform rayOrigin;

    public GameObject particals;

    public float speed = 10;

    RaycastHit2D hit;

    void Update()
    {
        hit = Physics2D.Raycast(rayOrigin.position, rayOrigin.up, 100);
        if (hit.collider != null)
        {
            Debug.Log(hit.transform.name);
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("player");
                Rigidbody2D rb = transform.AddComponent<Rigidbody2D>();
                rb.gravityScale = speed;
                rb.freezeRotation = true;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            }          
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(particals, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(rayOrigin.position, rayOrigin.position + rayOrigin.up * 100);
    }
}
