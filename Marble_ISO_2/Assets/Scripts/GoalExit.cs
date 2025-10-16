using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalExit : MonoBehaviour
{
    public Transform transDestination;
    public GameObject playerGameObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerGameObject.SetActive(false);
            playerGameObject.transform.position = transDestination.position;
            playerGameObject.SetActive(true);
        }
    }
}
