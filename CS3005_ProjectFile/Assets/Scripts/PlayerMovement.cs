using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;

    [Header("Movement")]
    public float moveSpeed = 10f;
    Vector2 movement;

    [Header("Components")]
    public Rigidbody2D rigid;
    public SpriteRenderer sprite;

    public float linearDrag = 4f;

    public bool isGrounded = false;

    // Update is called once per frame
    void Update()
    {
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
            rigid.velocity = new Vector2(moveSpeed, 0);
            sprite.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.velocity = new Vector2(-moveSpeed, 0);
            sprite.flipX = true;
        }
        else
        {
            rigid.velocity = new Vector2(0, 0);
        }

        // Triggers animation - Mathf.Abs takes value and makes sure value is always positive
        anim.SetFloat("speed", Mathf.Abs(horizontal));
    }
}
