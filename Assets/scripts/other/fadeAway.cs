using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fadeAway : MonoBehaviour
{
 

    void Start()
    {
       
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneLoader.instance.loadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
