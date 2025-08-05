using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fadeAway : MonoBehaviour
{

    public bool GobackToMenu = false;

    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(GobackToMenu)
            {
                SceneLoader.instance.loadScene(0);
            }
            else
            {
                SceneLoader.instance.loadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
