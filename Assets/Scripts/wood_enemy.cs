using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood_enemy : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    private Rigidbody2D myRigidBody;
    private Animator animator;
    
    void Start()
    {
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
            animator.SetBool("isWalking",true);
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
}