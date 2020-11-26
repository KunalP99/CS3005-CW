using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldJump : MonoBehaviour
{
    public Rigidbody2D rigid;
    // How much we are going to multiply gravity when player is falling down
    public float fallMultiplier = 3f;
    public float lowMultiplier = 7f;

    // Update is called once per frame
    void Update()
    {
        // If we are falling...
        if (rigid.velocity.y < 0)
        {
            // Applies fall multiplier to gravity which by default is set to -9.81, we use Vector2.up as we are only dealing with vertical movement
            rigid.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        // If we are jumping up and not holding down space (tapping space)... 
        else if (rigid.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            // Applies low jump multiplier which gives us the lowest possible jump
            rigid.velocity += Vector2.up * Physics2D.gravity.y * (lowMultiplier - 1) * Time.deltaTime;
        }
    }
}
