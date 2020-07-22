using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow2 : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    public float speed;
    public int health;
    private bool _playerAlive;
    public Vector2 targetPosition;
    private float dazedTime;
    public float startDazedTime;

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
            targetPosition.x = target.position.x;
            targetPosition.y = transform.position.y;

        } 
        if (health <= 0){
            Destroy(gameObject);
        if(dazedTime <= 0){
                speed = 5;
            } else {
                speed = 0;
                dazedTime -= Time.deltaTime;

            }
    }
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        health -= damage;
        Debug.Log("damage TAKEN");
    }

    private IEnumerator BeginPlay()
    {
        yield return new WaitForSeconds(1f);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    private void LateUpdate()
    {
        if (_playerAlive)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}



