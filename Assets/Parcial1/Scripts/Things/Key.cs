using System;
using System.Collections;
using System.Collections.Generic;
using Things;
using UnityEngine;

public class Key : MonoBehaviour {
    private bool pickUpAllowed;
    private GameObject _player;
    [SerializeField]private GameManager _gameManager;

    public GameObject Player
    {
        set => _player = value;
    }

    private void Update() {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pressed E");
            
            PickUp();
        }
    }

    private void PickUp()
    {
        _gameManager.GetComponent<Pila>().Apilar(gameObject.name.Normalize());
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pickUpAllowed = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pickUpAllowed = false;
        }
    }

    
  

}

