using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    [SerializeField] public string LoadScene;
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Find("Player").SendMessage("Finish");
        if (other.gameObject.CompareTag("player"))
        {
            SceneManager.LoadScene(LoadScene, LoadSceneMode.Single);
        }
    }
}