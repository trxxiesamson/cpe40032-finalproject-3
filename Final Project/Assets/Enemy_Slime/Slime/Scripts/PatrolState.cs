using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : StateMachineBehaviour
{
    float timer;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;

    Transform player;
    float chaseRange = 8;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // gameObject with the tag "Player"
        agent = animator.GetComponent<NavMeshAgent>(); // gets navmesh
        agent.speed = 1.5f;
        timer = 0;
        GameObject go = GameObject.FindGameObjectWithTag("WayPoints"); // gameObjects with the tag "Waypoints" for the patroling
        foreach(Transform t in go.transform)
            wayPoints.Add(t);

        agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);

        timer += Time.deltaTime;
        if(timer > 10)
            animator.SetBool("isPatroling", false); // stops patroling after over 10 secs has passed

        float distance = Vector3.Distance(player.position, animator.transform.position);
        if(distance < chaseRange)
            animator.SetBool("isChasing", true); // chasing activates when player is in the set distance
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

}
