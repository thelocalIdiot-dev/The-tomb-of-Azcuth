using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseManager : MonoBehaviour
{
    public bool pause;

    public GameObject PauseMenu;

    public static pauseManager instance;

    private void Awake()
    {
        instance = this; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pause == false)
        {
            Pause();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pause == true)
        {
            UnPause();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        pause = true;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        pause = false;
    }
}
