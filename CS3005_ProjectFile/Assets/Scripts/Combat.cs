using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Animator anim;
    public float attackSpeed;
    float attackCooldown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
    }
}
