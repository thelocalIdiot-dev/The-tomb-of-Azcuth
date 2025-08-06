using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnet : MonoBehaviour
{
    public Transform rayOrigin;

    public float maxDistance = 100, power;

    RaycastHit2D hit;

    public bool pull, active = tru;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Physics2D.Raycast(rayOrigin.position, -rayOrigin.up, maxDistance);

        
        RaycastHit2D hit = Physics2D.BoxCast(rayOrigin.position, transform.localScale, 0, -rayOrigin.up, maxDistance);
        Rigidbody2D rb = hit.transform.GetComponent<Rigidbody2D>();
        Debug.Log(hit.transform.name);
        if(rb != null && hit.transform.CompareTag("Metal box") && active)
        {
            if (pull)
            {
                rb.AddForce((transform.position - rb.transform.position) * power, ForceMode2D.Force);
            }
            else
            {
                rb.AddForce((rb.transform.position - transform.position) * power, ForceMode2D.Force);
            }
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawLine(rayOrigin.position, rayOrigin.position + -rayOrigin.up * maxDistance);
        Gizmos.DrawWireCube((rayOrigin.position + (rayOrigin.position + -rayOrigin.up * maxDistance)) / 2, new Vector3(transform.localScale.x, maxDistance));

    }


}
