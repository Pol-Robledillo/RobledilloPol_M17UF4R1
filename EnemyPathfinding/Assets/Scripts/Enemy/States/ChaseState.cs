using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ChaseState", menuName = "StatesSO/Chase")]

public class ChaseState : StateSO
{
    public override void OnStateEnter(EnemyBehaviour enemy)
    {
    }
    public override void OnStateUpdate(EnemyBehaviour enemy)
    {
        enemy.pathfinding.Chase();
    }
    public override void OnStateExit(EnemyBehaviour enemy)
    {
    }
}
