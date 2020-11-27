using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;

    public float attackSpeed;
    public float range = 0.5f;

    public LayerMask enemies;

    float attackCooldown;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > attackCooldown)
        {
            Attack();
            // Determines how quick character can attack as at this point in time, attackSpeed is 1 second longer then Time.time and after 1 second Time.time becomes longer
            attackCooldown = Time.time + attackSpeed;
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack");

        // Creates a cicle and collects all objects that it hits and stores them in enemiesHit array
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, range, enemies);

        foreach (Collider2D enemies in enemiesHit)
        {
            // All Blue objects will take damage of 100 when hit by sword
            enemies.GetComponent<Blue>().TakeDamage(100);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
           
        Gizmos.DrawWireSphere(attackPoint.position, range);
    }
}
