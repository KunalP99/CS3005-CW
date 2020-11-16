using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rigid;
    public float jumpHeight = 10f;

    Vector2 movement;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        //Input - getting horizontal and vertical movement and storing it in Vector2 movement
        movement.x = Input.GetAxisRaw("Horizontal"); //gives value from -1 to 0. Right arrow = 1, left arrow = -1, nothing = 0

        if (Input.GetButtonDown("Jump"))
        {
            rigid.velocity = Vector2.up * jumpHeight;
        }
    }

    void FixedUpdate() //when dealing with physics (Rigidbody2d) used fixed update otherwise use update
    {
        //Movement
        rigid.MovePosition(rigid.position + movement * moveSpeed * Time.deltaTime);
    }
}
