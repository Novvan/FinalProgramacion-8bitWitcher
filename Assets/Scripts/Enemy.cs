using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}



public class Enemy : MonoBehaviour
{
    public EnemyState currenState;
    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     CheckHealth();   
    }


private void CheckHealth(){
    

        if(health <= 0){
            GameObject.Destroy(gameObject);
        }
    
}

}
