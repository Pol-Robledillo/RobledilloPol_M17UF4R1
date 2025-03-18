using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RunAwayState", menuName = "StatesSO/RunAway")]

public class RunAwayState : StateSO
{
    public override void OnStateEnter(EnemyBehaviour enemy)
    {
    }
    public override void OnStateUpdate(EnemyBehaviour enemy)
    {
        enemy.pathfinding.RunAway();
    }
    public override void OnStateExit(EnemyBehaviour enemy)
    {
    }
}
