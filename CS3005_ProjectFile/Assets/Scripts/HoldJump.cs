using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldJump : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float fallMultiplier = 2.5f;
    public float lowMultiplier = 2f;

    // Update is called once per frame
    void Update()
    {
        if (rigid.velocity.y < 0)
        {
            rigid.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rigid.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rigid.velocity += Vector2.up * Physics2D.gravity.y * (lowMultiplier - 1) * Time.deltaTime;
        }
    }
}
