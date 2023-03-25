using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    Transform player;
    private Controller playerHealth; // reference to the controller
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Finds the GameObject with the tag "Player"
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player); 
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if(distance < 3.5f)
            animator.SetBool("isAttacking", false); 

        if (playerHealth.healthBar.value <= 0) // if player's healthbar value is less than or equal to zero, animation of attack will be stopped
            animator.SetBool("isAttacking", false);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}
