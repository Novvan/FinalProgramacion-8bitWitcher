using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication;
using UnityEditor;
using UnityEngine;

public class wood_enemy : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    private Rigidbody2D myRigidBody;
    private Animator animator;
    private float _baseHealth = 5;
    private float _health;

    public float Health => _health;

    private float _maxHealth = 300.0f;
    public GameObject playerSpawn;
    public float dist;
    void Start()
    {
        _setHealth();
        animator= GetComponent<Animator>();
        currenState = EnemyState.idle;
        myRigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }
    
    void FixedUpdate()
    {
        CheckDistance();
    }
    void CheckDistance()
    {
        if (currenState == EnemyState.idle || currenState == EnemyState.walk && currenState != EnemyState.stagger && Vector3.Distance(target.position, transform.position)<= chaseRadius && Vector3.Distance(target.position,transform.position)> attackRadius)
        {

            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            myRigidBody.MovePosition(temp);
            //animator.SetBool("isMoving",true);
            ChangeState(EnemyState.walk);
            
        }
    }

    private void ChangeState(EnemyState newstate)
    {
        if (currenState != newstate)
        {
            currenState = newstate;
        }
    }


    private void _setHealth()
    {
        dist = Vector2.Distance(playerSpawn.transform.position,this.transform.position);
        _health = _baseHealth * dist *0.5f;
        if (_health > _maxHealth) _health = _maxHealth;
        //Debug.Log("Enemy health = "+_health);
        //Debug.Log("Distance to player: "+ dist);
    }
}