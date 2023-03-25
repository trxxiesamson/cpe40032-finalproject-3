using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleBehaviour : StateMachineBehaviour
{
    //variables
    public float timer;
    public float minTime;
    public float maxTime;

    //referencing
    public Transform player;
    private int rand;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 2);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timer = Random.Range(minTime, maxTime);
        if (rand == 0)
        {
            animator.SetTrigger("attack");
        }
        else
        {
            animator.SetTrigger("walk");
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);          //always looking at the player
        if (timer <= minTime)
        {
            animator.SetTrigger("walk");        //random time for unexpected boss attack
        }
        else if (timer > minTime)
        {
            animator.SetTrigger("attack");
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}
