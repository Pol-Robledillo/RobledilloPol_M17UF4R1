using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public GameObject pointA, pointB, currentPoint;

    public void Start()
    {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        currentPoint = pointA;
        Patrol();
    }
    public void Patrol()
    {
        StopAllCoroutines();
        StartCoroutine(PatrolRoutine());
    }
    public IEnumerator PatrolRoutine()
    {
        while (true)
        {
            agent.SetDestination(currentPoint.transform.position);
            if (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
            {
                yield return null;
            }
            currentPoint = currentPoint == pointA ? pointB : pointA;
            yield return new WaitForSeconds(1f);
        }
    }
    public void Chase()
    {
        StopAllCoroutines();
        agent.SetDestination(target.transform.position);
    }
    public void RunAway()
    {
        StopAllCoroutines();
        Vector3 runDirection = transform.position - target.transform.position;
        runDirection.Normalize();
        Vector3 runTo = transform.position + runDirection * 10;
        agent.SetDestination(runTo);
    }
}
