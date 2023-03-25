using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrolBehaviour : StateMachineBehaviour
{
    //variables
    public float timer;
    public float minTime;
    public float maxTime;

    private float waitTime;
    public float startWaitTime;

    //creating a list for waypoints and getting the boss component
    List<Transform> wayPoints = new List<Transform>();
    private int randomSpot;
    NavMeshAgent agent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        waitTime = startWaitTime;

        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 1.5f;
        GameObject go = GameObject.FindGameObjectWithTag("WayPoints");      
        foreach (Transform t in go.transform)
            wayPoints.Add(t);           //iterates each waypoint transform

        randomSpot = Random.Range(0, wayPoints.Count);
        agent.SetDestination(wayPoints[randomSpot].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= minTime)
        {
            animator.SetTrigger("idle");
        }
        else
        {
            timer -= Time.deltaTime;
        }

        animator.transform.LookAt(wayPoints[randomSpot]);   //look at player's position
        agent.SetDestination(wayPoints[randomSpot].position);       //go to a random waypoint spot
        if (Vector3.Distance(animator.transform.position, wayPoints[randomSpot].position) < 0.2f)       //stops just near the player
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, wayPoints.Count);      
                waitTime = startWaitTime;           //waiting time before transfering to another spot
            }
            else
            {
                waitTime -= Time.deltaTime;         //resets timer
            }
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
