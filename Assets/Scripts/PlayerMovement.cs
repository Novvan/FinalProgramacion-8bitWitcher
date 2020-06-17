using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

public enum PlayerState
{
    walk,
    attack,
    quen,
    igni,
    aard,
    yrden,
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody2D;
    private Vector3 change;
    private Animator Animator;

    private void Start()
    {
        currentState = PlayerState.walk;
        Animator = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        Animator.SetFloat("moveX", 0);
        Animator.SetFloat("moveY", -1);
    }

    private void Update()
    {
        change = Vector3.zero;
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            change.x = Input.GetAxisRaw("Horizontal");
        }
        else if (Input.GetAxisRaw("Vertical") != 0)
        {
            change.y = Input.GetAxisRaw("Vertical");
        }

        if (currentState == PlayerState.walk)
        {
            UpdateAnimAndMove();
        }
    }


    void UpdateAnimAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveChar();
            Animator.SetFloat("moveX", change.x);
            Animator.SetFloat("moveY", change.y);
            Animator.SetBool("isMoving", true);
        }
        else
        {
            Animator.SetBool("isMoving", false);
        }
    }

    void MoveChar()
    {
        change.Normalize();
        myRigidbody2D.MovePosition(
            transform.position + Time.deltaTime * change * speed
        );
    }
}