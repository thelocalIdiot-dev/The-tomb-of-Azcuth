using DG.Tweening;
using SmallHedge.SoundManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Vector2 original;

    public Transform target;

    public Transform door;

    public float speed, delay;

    public bool opened;
    void Start()
    {
        original = transform.position;
    }

    private void Update()
    {
        if(opened)
        {
            door.position = Vector2.MoveTowards(door.position, target.position, speed);
        }
        else {
            door.position = Vector2.MoveTowards(door.position, original, speed);
        }
    }

    public void DOopen()
    {        
        StartCoroutine(openClose());
    }
    

    public void open()
    {
        SoundManager.PlaySound(SoundType.door);
        opened = true;
    }

    public void close()
    {
        opened = false;
    }

    public IEnumerator openClose()
    {
        open();

        yield return new WaitForSeconds(delay);

        close();
    }
}
