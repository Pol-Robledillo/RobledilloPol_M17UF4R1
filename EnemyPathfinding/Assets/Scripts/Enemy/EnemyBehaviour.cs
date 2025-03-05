using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int HP;
    public GameObject target;
    public int DamagedHP;
    public bool InVisionRange = false, InAttackRange = false;
    private Pathfinding pathfinding;
    private EnemyVision enemyVision;
    public StateSO currentNode;
    public List<StateSO> Nodes;

    void Start()
    {
        pathfinding = GetComponent<Pathfinding>();
        enemyVision = GetComponent<EnemyVision>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            if (enemyVision.CheckEnemyVision(collision.gameObject))
            {
                target = collision.gameObject;
                InVisionRange = true;
                CheckEndingConditions();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (enemyVision.CheckEnemyVision(other.gameObject))
            {
                target = other.gameObject;
                InVisionRange = true;
                CheckEndingConditions();
            }
            else
            {
                InVisionRange = false;
                CheckEndingConditions();
            }
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            InVisionRange = false;
            CheckEndingConditions();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        InAttackRange = true;
        CheckEndingConditions();
    }
    private void OnCollisionExit(Collision collision)
    {
        InAttackRange = false;
        CheckEndingConditions();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HP--;
            CheckEndingConditions();
        }
        currentNode.OnStateUpdate(this);
    }
    public void CheckEndingConditions()
    {
        foreach (ConditionSO condition in currentNode.EndConditions)
            if (condition.CheckCondition(this) == condition.answer) ExitCurrentNode();
    }
    public void ExitCurrentNode()
    {
        foreach (StateSO stateSO in Nodes)
        {
            if (stateSO.StartCondition == null)
            {
                EnterNewState(stateSO);
                break;
            }
            else
            {
                if (stateSO.StartCondition.CheckCondition(this) == stateSO.StartCondition.answer)
                {
                    EnterNewState(stateSO);
                    break;
                }
            }
        }
        currentNode.OnStateEnter(this);
    }
    private void EnterNewState(StateSO state)
    {
        currentNode.OnStateExit(this);
        currentNode = state;
        currentNode.OnStateEnter(this);
    }
}