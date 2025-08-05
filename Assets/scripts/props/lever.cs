using SmallHedge.SoundManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    public bool right = true;

    public void turnLever()
    {
        SoundManager.PlaySound(SoundType.Lever);
        right = !right;
        GetComponent<Animator>().SetTrigger("click");       
    }
}
