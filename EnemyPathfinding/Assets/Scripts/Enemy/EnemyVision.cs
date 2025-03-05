using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public float fieldOfView = 90f;
    public bool CheckEnemyVision(GameObject target)
    {
        Vector3 directionToTarget = target.transform.position - transform.position;
        directionToTarget.Normalize();
        float dot = Vector3.Dot(transform.forward, directionToTarget);
        float angle = Mathf.Cos(fieldOfView * Mathf.Deg2Rad);
        if (dot > angle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToTarget, out hit))
            {
                if (hit.collider.gameObject == target)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
