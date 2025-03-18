using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DeathCondition", menuName = "ConditionsSO/Death")]

public class DeathCondition : ConditionSO
{
    public override bool CheckCondition(EnemyBehaviour enemy)
    {
        return enemy.HP <= 0;
    }
}
