using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target2 : MonoBehaviour
{
   public int coinReward = 5; 
  public float health = 10f ;
  bool die = false ;
  bool pain = false ;
  
  
  public Animator animator ;
  public UnityEngine.AI.NavMeshAgent agent; 

      

     void Update()
    {
        
    }

    public void takeDamage(float amount ){
      health -= amount ;
      // if(health <= 10){
      //   pain = true ;
      //   Pain();
      // }
      if (health <= 0){
        die = true ;
        Die();
      }

    }

    void Die(){
      animator.SetBool("dead",die);
      
      
      if (agent != null)
        {
            agent.isStopped = true; 
            agent.enabled = false;  
        }
        Coins.Instance.AddCoins(coinReward);


    }

    void Pain(){
     animator.SetBool("pain",pain);
    }


}
