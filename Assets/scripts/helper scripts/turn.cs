using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn : MonoBehaviour
{
    public void rotate(float amount)
    {
        transform.Rotate(0, 0, amount);
    }
}
