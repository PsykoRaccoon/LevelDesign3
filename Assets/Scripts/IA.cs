using UnityEngine.AI;
using UnityEngine;
using System.Collections;

public class IA : MonoBehaviour
{
    public NavMeshAgent agent;
    [Header("Patrullaje")]
    public float patrolRadius;

    private Vector3 patrolPoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNewPatrolPoint();
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (!agent.hasPath || agent.remainingDistance < 1f)
        {
            SetNewPatrolPoint();
        }
    }

    void SetNewPatrolPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, 1))
        {
            patrolPoint = hit.position;
            agent.SetDestination(patrolPoint);
        }
    }
}