using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public int health;
    public float speed;

    private Animator anim;

    private void Start(){
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
    }
    private void Update(){
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    public void TakeDamage(int damage){
        health -= damage;
        Debug.Log("damage TAKEN");
    }
}

