using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateSO : ScriptableObject
{
    public ConditionSO StartCondition;
    public List<ConditionSO> EndConditions;
    public abstract void OnStateEnter(EnemyBehaviour enemy);
    public abstract void OnStateUpdate(EnemyBehaviour enemy);
    public abstract void OnStateExit(EnemyBehaviour enemy);

}