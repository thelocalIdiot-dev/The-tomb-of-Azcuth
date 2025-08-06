using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn : MonoBehaviour
{

    public Transform player;
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && Vector3.Distance(this.transform.position, player.position) < 20f)
        {
            rotate(-10f); // Gira 45 grados al presionar R
        }

        else if (Input.GetKey(KeyCode.Q) && Vector3.Distance(this.transform.position, player.position) < 20f)
        {
            rotate(10f); // Gira -45 grados al presionar Q
        }
        Debug.Log(Vector3.Distance(this.transform.position, player.position));
    }
    public void rotate(float amount)
    {
        transform.Rotate(0, 0, amount * Time.deltaTime);
    }
}
