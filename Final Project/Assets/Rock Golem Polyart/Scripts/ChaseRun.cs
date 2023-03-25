using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseRun : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       agent = animator.GetComponent<NavMeshAgent>();
       player = GameObject.FindGameObjectWithTag("Player").transform; // GameObject with tag "Player"
       agent.speed = 2.5f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > 9)
            animator.SetBool("isChasing", false); // chasing deactivates when not in set distance
            
        if (distance < 2.5f)
        ManageAudio.instance.Play("GolemHit");
            animator.SetBool("isAttacking", true); // golem attacks when in set range
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      agent.SetDestination(animator.transform.position);
    }

}
