using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    public Rigidbody2D rigid;
    public Animator anim;

    public float startFloat;

    private float floatDuration;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        floatDuration = startFloat;
    }

    // Update is called once per frame
    void Update()
    {
        // If not dashing then player can press key to set direction to 1 which will allow player to float
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                direction = 1;
            }
        }
        else
        {
            if (floatDuration <= 0)
            {
                anim.SetBool("Float", false);
                direction = 0;
                floatDuration = startFloat;
            }
            else
            {
                // Slowly decrease float time
                floatDuration -= Time.deltaTime;

                if (direction == 1)
                {
                    anim.SetBool("Float", true);
                    // Player will float up for a short duration
                    rigid.velocity = Vector2.up;
                }
            }

        }
    }
}
