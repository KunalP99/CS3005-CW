using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;

    [Header("Movement")]
    public float moveSpeed = 10f;
    public float jumpVelocity;
    Vector2 movement;

    [Header("Components")]
    public Rigidbody2D rigid;
    public SpriteRenderer sprite;

    public bool isGrounded = false;

    // Update is called once per frame
    void Update()
    {
        Jump();

        // Defined on a scale from -1 to +1 (-1 = left, 1 = right and 0 = idle (WASD))
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    // When dealing with physics (Rigidbody2d) used fixed update otherwise use update
    void FixedUpdate()
    {
        // We only want to move left and right, we use movement.x as the parameter
        Move(movement.x);
    }

    void Move(float horizontal)
    {
        // Moves the character 

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rigid.velocity = new Vector2(moveSpeed, rigid.velocity.y);
            sprite.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.velocity = new Vector2(-moveSpeed, rigid.velocity.y);
            sprite.flipX = true;
        }

        // Triggers animation - Mathf.Abs takes value and makes sure value is always positive
        anim.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rigid.velocity = Vector2.up * jumpVelocity;
        }
    }
}
