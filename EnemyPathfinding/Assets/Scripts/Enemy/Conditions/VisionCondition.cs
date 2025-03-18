using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "VisionCondition", menuName = "ConditionsSO/Vision")]

public class VisionCondition : ConditionSO
{
    public override bool CheckCondition(EnemyBehaviour enemy)
    {
        return enemy.InVisionRange;
    }
}
