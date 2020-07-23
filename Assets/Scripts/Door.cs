using System;
using System.Collections;
using System.Collections.Generic;
using Things;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameManager GameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //if (GameManager.Pila.Cantidad() == 3) 
            if (GameManager.Stack.Count == 3)
            {
                other.SendMessage("Finish");
            }
            else
            {
                Debug.Log("Faltan " + (3 - GameManager.Stack.Count) + " llaves");
            }
        }
    }
}