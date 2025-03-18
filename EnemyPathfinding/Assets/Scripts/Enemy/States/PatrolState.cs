using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PatrolState", menuName = "StatesSO/Patrol")]

public class PatrolState : StateSO
{
    public override void OnStateEnter(EnemyBehaviour enemy)
    {
    }
    public override void OnStateUpdate(EnemyBehaviour enemy)
    {
        enemy.pathfinding.Patrol();
    }
    public override void OnStateExit(EnemyBehaviour enemy)
    {
    }
}
