using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    public float speed;
    private bool _playerAlive;

    private Transform target;


    private void Start()
    {
        StartCoroutine(BeginPlay());
    }

    void Update()
    {
        _playerAlive = _gameManager.isAlive;
        
        if (_playerAlive)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }

    private void LateUpdate()
    {
        if (_playerAlive)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);            
        }
    }

    IEnumerator BeginPlay()
    {
        yield return new WaitForSeconds(1f);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }
}
