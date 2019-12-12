using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockback;
    public float knockTime;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                
                var EnemyComp = enemy.GetComponent<Enemy>();

                EnemyComp.currenState = EnemyState.stagger;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * knockback;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                EnemyComp.health -= 1;
                StartCoroutine(KnockCo(enemy));
            }
        }
        else if(other.gameObject.CompareTag("player")){
            Rigidbody2D player = other.GetComponent<Rigidbody2D>();
            if(player != null)
            {
                var playerComp = player.GetComponent<Character>();
                Vector2 difference = player.transform.position - transform.position;
                difference = difference.normalized * knockback;
                player.AddForce(difference, ForceMode2D.Impulse);
                playerComp.CurrentHealth -= gameObject.GetComponent<Enemy>().baseAttack;
                StartCoroutine(KnockCo(player));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<Enemy>().currenState = EnemyState.idle;
        }
    }
}
