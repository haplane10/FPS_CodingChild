using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour
{
    public Transform[] targets;
    public NavMeshAgent navMeshAgent;
    public AIType aiType;
    public Slider hpSlider;
    public float hpValue = 100;

    int targetIdx = 0;
    [SerializeField] Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        switch (aiType)
        {
            case AIType.None:
                {
                    
                }
                break;
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
                {
                    if (!player)
                    {
                        if (!navMeshAgent.hasPath || navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                        {
                            navMeshAgent.SetDestination(targets[targetIdx].position);
                            targetIdx++;
                            if (targetIdx >= targets.Length)
                            {
                                targetIdx = 0;
                            }
                        }
                    }
                }
                break;
            case AIType.Follow:
                {
                    navMeshAgent.SetDestination(player.position);
                }
                break;
            default:
                break;
        }

    }

    Coroutine Co_WaitAndFollow;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Co_WaitAndFollow = StartCoroutine(co_WaitAndFollow(3f));
            player = other.transform;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(Co_WaitAndFollow);
            player = null;
            aiType = AIType.WaitAndMove;
        }
    }

    IEnumerator co_WaitAndFollow(float time)
    {
        navMeshAgent.isStopped = true;
        yield return new WaitForSeconds(time);
        navMeshAgent.isStopped = false;
        aiType = AIType.Follow;
    }

    public Animator animator;

    public void GetDamage(float value)
    {
        hpValue -= value;
        hpSlider.value = hpValue;

        if (hpValue <= 0)
        {
            // die
            animator.SetTrigger("Death");
            navMeshAgent.isStopped = true;
            Destroy(gameObject, 3f);
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
