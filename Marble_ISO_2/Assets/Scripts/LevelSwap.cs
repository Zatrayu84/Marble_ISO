using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSwap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LevelExit")
        {
            Debug.Log("Loading Level next, from level exit");
            SceneManager.LoadScene(1);
        }
    }
}
