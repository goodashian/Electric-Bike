using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] [Range(1, 20)] private float patrolDist = 10f;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (WithinDistance())
        {
            ChaseTarget();
        }
        else
        {
            AbandonChase();
        }
    }

    private bool WithinDistance()
    {
        float sqrDist = Vector3.SqrMagnitude(target.position - transform.position);
        return sqrDist <= patrolDist * patrolDist;
    }
    
    //todo: for now, just chase
    private void ChaseTarget()
    {
        agent.SetDestination(target.position);
    }

    //todo: for now, just stop at where it is
    private void AbandonChase()
    {
        agent.SetDestination(transform.position);
    }


#if UNITY_EDITOR
    //todo: for debug use, remove later 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, patrolDist);
    }
#endif
}

