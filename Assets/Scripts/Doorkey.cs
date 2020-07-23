using System.Collections;
using System.Collections.Generic;
using Things;
using UnityEngine;

public class DoorKey: MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PickUp();
    }
    private void PickUp()
    {
        gameManager.Stack.Push("KEY");
        //gameManager.Pila.Apilar("KEY");
        Destroy(gameObject);
    }
}
