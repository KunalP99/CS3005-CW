using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public TriggerBehaviour trigger;
    public Animator anim;
    public Rigidbody2D rigid;
    public SpriteRenderer sprite;

    public bool isGrounded = false;
    public float moveSpeed = 10f;
    public float jumpVelocity;

    public float kb;
    public float kbDuration;
    public float kbCounter;
    public bool kbRight;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        Jump();

        // Defined on a scale from -1 to +1 (-1 = left, 1 = right and 0 = idle (WASD))
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //anim.SetFloat("Horizontal", movement.x);
    }

    // When dealing with physics (Rigidbody2d) used fixed update otherwise use update
    void FixedUpdate()
    {
        // Player can only move once knockback is complete
        if (kbCounter <= 0)
        {
            // We only want to move left and right, we use movement.x as the parameter
            Move(movement.x);
        } 
        else
        {
            // If enemy is on left then knock back right else knock back left
            if (kbRight == true)
            {
                rigid.velocity = new Vector2(-kb, kb);
            }
            if (kbRight == false)
            {
                rigid.velocity = new Vector2(kb, kb);
            }

            // The counter will always need to go downwards for player to always move after knockback finishes
            kbCounter -= Time.deltaTime;
        }

    }

    void Move(float horizontal)
    {
        // Moves the character 

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // rigid.velocity.y - sets the position of y to the velocity of rigid so player can move while in the air
            rigid.velocity = new Vector2(moveSpeed, rigid.velocity.y);
            FaceRight();
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.velocity = new Vector2(-moveSpeed, rigid.velocity.y);
            FaceLeft();
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

    void FaceLeft()
    {
        // Gets the scale from the transform of Knight and changes it so x value changes to -1 
        transform.localScale = new Vector3(-1, 1, 1);
    }

    void FaceRight()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
}
