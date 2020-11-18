using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rigid;
    public Animator anim;

    public float followRange;
    public float moveSpeed;

     void Start()
    {
        
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
        // Shortcut to right 0, 0 (Stopping movement)
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

}
