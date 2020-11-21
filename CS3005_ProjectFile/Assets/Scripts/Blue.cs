using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    public PlayerMovement playerScript;

    public Transform player;
    public Rigidbody2D rigid;
    public Animator anim;

    public float followRange;
    public float moveSpeed;

    public int maxHealth = 100;
    int currentHealth;

     void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Storing distance from enemy object to player object
        float toPlayer = Vector2.Distance(transform.position, player.position);

        if (toPlayer < followRange)
        {
            Chase();
        }
        else if (toPlayer > followRange)
        {
            StopChase();
        }
    }

    void Chase()
    {
        if (transform.position.x < player.position.x)
        {
            // Will move right towards player, y is 0 so enemy doesn't go up or down
            rigid.velocity = new Vector2(moveSpeed, 0);
            FaceRight();
            anim.SetBool("isFollowing", true);
        }
        else if (transform.position.x > player.position.x)
        {
            // Will move left towards the player
            rigid.velocity = new Vector2(-moveSpeed, 0);
            FaceLeft();
            anim.SetBool("isFollowing", true);
        }
    }

    void StopChase()
    {
        // Shortcut to write 0, 0 (Stopping movement)
        rigid.velocity = Vector2.zero;
        anim.SetBool("isFollowing", false);
    }

    void FaceLeft()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    void FaceRight()
    {
        transform.localScale = new Vector3(-1, 1, 1);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            death();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerScript.kbCounter = playerScript.kbDuration;

            // Checks if the position of player is on the left which will set kbRight to true in the playermovement script
            if (other.transform.position.x < transform.position.x)
            {
                playerScript.kbRight = true;
            }
            else
            {
                playerScript.kbRight = false;
            }
        }
    }
    
    void death()
    {
        Destroy(gameObject);
        //this.enabled = false;
    }

}
