using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBehaviour : StateMachineBehaviour
{
    private int rand;

    // Start funtion, called when animation first plays
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 2);

        if (rand == 0)
        {
            animator.SetTrigger("idle");
        }
        else
        {
            animator.SetTrigger("jump");
        }
    }

    // Called every single frame, as long as intro animation is played
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // Called once, when intro animation stops playing
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
