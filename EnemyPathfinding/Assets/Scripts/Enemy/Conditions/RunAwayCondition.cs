using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RunAwayCondition", menuName = "ConditionsSO/RunAway")]

public class RunAwayCondition : ConditionSO
{
    public override bool CheckCondition(EnemyBehaviour enemy)
    {
        return enemy.runAway;
    }
}
