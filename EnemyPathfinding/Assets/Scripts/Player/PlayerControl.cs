using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour, IDamageable
{
    public float speed = 5.0f;
    public int HP = 100;
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical);
        transform.Translate(move * speed * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
    }
}
