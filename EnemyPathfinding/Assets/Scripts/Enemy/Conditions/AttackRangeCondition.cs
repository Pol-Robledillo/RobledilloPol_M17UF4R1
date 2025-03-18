using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AttackRangeCondition", menuName = "ConditionsSO/AttackRange")]

public class AttackRangeCondition : ConditionSO
{
    public override bool CheckCondition(EnemyBehaviour enemy)
    {
        return enemy.InAttackRange;
    }
}
