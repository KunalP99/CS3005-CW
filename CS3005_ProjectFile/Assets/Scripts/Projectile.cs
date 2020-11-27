using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rigid;

    public float speed;

    GameObject[] enemiesHit;
    GameObject[] boss;

    void Awake()
    {
        // Checks if the projcetile has rotated, which if it has, will determine what direction it goes
        if (transform.localRotation.z > 0)
        {
            // Will only travel in a straight line, away from character
            rigid.AddForce(new Vector2(-1, 0) * speed, ForceMode2D.Impulse);
        }
        else
        {
            rigid.AddForce(new Vector2(1, 0) * speed, ForceMode2D.Impulse);
        }

        enemiesHit = GameObject.FindGameObjectsWithTag("Enemy");
        boss = GameObject.FindGameObjectsWithTag("Boss");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            foreach (GameObject enemies in enemiesHit)
            {
                // All Blue objects will take damage of 100 when hit by sword
                enemies.GetComponent<Blue>().TakeDamage(100);
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.tag == "Boss")
        {
            foreach (GameObject boss in boss)
            {
                boss.GetComponent<Boss>().TakeDamage(100);
                Destroy(gameObject);
            }
        }
    }

}
