using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IDamageable
{
    public int HP = 100;
    public float attackRange = 5;
    public GameObject target;
    public bool InVisionRange = false, InAttackRange = false, runAway = false;
    public Pathfinding pathfinding;
    private EnemyVision enemyVision;
    public StateSO currentNode;
    public List<StateSO> Nodes;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
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
                InAttackRange = Vector3.Distance(transform.position, target.transform.position) < attackRange;
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(25);
        }
        currentNode.OnStateUpdate(this);
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP < 50)
        {
            runAway = true;
        }
        CheckEndingConditions();
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