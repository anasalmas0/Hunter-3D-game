using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMovment : MonoBehaviour
{
   public UnityEngine.AI.NavMeshAgent agent; 
    public Vector3 areaCenter; 
    public float areaRadius = 10f; 

    void Start()
    {
        
        if (agent == null)
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        
        MoveToRandomPosition();
    }

    void MoveToRandomPosition()
    {
        
        Vector3 randomDirection = Random.insideUnitSphere * areaRadius;
        randomDirection += areaCenter;

       
        if (UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out UnityEngine.AI.NavMeshHit hit, areaRadius, UnityEngine.AI.NavMesh.AllAreas))
        {
            
            agent.SetDestination(hit.position);
        }
    }

    void Update()
    {
        
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            
            MoveToRandomPosition();
        }
    }
}




   

