using Dialog;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogZone : MonoBehaviour
{
    public string[] text;
    public bool used = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!used)
        {
            for (int i = 0; i < text.Length; i++)
            {
                DialogManager.ShowThought(text[i]);
            }
            used = true;
        }        
    }

    private void Update()
    {
        if (used)
        {
            Destroy(gameObject);
        }
    }
}
