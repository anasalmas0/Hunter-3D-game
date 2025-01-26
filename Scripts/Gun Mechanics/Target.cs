using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int coinReward = 5; 
    public float health = 10f;
    bool die = false ;
    float speed = -100f;
    public Rigidbody rigidBody ;
    public Animator  animator;


    
    void Update()
    {
        
        rigidBody.AddForce(0,0,speed);
        
        
    }

    public void TakeDamage (float amount) {
        health -= amount ;
        if(health <= 0 ) {
            die = true ;

            Die();
        }
    }

    void Die(){
        
        animator.SetBool("Died",die);
        rigidBody.useGravity = true;
         rigidBody.AddForce(0,0,0);
         Coins.Instance.AddCoins(coinReward);    }


}
