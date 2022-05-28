using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationController : MonoBehaviour
{
    public Transform[] targets;
    public NavMeshAgent navMeshAgent;
    public AIType aiType;

    int targetIdx = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        switch (aiType)
        {
            case AIType.Patrol:
                if (!navMeshAgent.hasPath || navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                {
                    navMeshAgent.SetDestination(targets[targetIdx].position);
                    targetIdx++;
                    if (targetIdx >= targets.Length)
                    {
                        targetIdx = 0;
                    }
                }
                break;

            case AIType.Random:
                if (!navMeshAgent.hasPath || navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                {
                    targetIdx = Random.Range(0, targets.Length);
                    navMeshAgent.SetDestination(targets[targetIdx].position);
                }
                break;

            case AIType.WaitAndMove:
                break;
            case AIType.Follow:
                break;
            default:
                break;
        }

    }
}

public enum AIType
{
    None = 0,
    Patrol,
    Random,
    WaitAndMove,
    Follow
}
