using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chaseBehaviour : StateMachineBehaviour
{
    //values
    public float timer;
    public float minTime;
    public float maxTime;
    public float stoppingPoint;
    public float retreatPoint;

    private float timeBtwShot;
    public float startTimeBtwShot;

    //Other game objects components
    public GameObject projectile;
    public Transform player;
    public Transform castpoint;

    //Boss' components
    NavMeshAgent agent;
    private Vector3 pos;
    private Quaternion rot;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        castpoint = GameObject.FindGameObjectWithTag("castpoint").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 3.2f;
        timeBtwShot = startTimeBtwShot;
        pos = animator.transform.position;
        rot = animator.transform.rotation;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= minTime)       //if the 
        {
            animator.SetTrigger("idle");
        }
        else
        {
            timer -= Time.deltaTime;        //resets the timer
        }

        animator.transform.LookAt(player);      //looks at the player when stopped
        if (Vector3.Distance(pos, player.position) > stoppingPoint)     //chases the player
        {
            agent.SetDestination(player.position);
        }
        else if (Vector3.Distance(pos, player.position) < stoppingPoint && Vector3.Distance(pos, player.position) > retreatPoint)       //stops when near the players position
        {
            agent.SetDestination(agent.transform.position);
        }
        else if (Vector3.Distance(pos, player.position) < retreatPoint)         //retreats when player is going to the boss' destination
        {
            agent.SetDestination(player.position - pos);
        }

        if (timeBtwShot <= 0)           //shot at a certain time
        {
            Instantiate(projectile, castpoint.position, rot);
            timeBtwShot = startTimeBtwShot;
        }
        else
        {
            timeBtwShot -= Time.deltaTime;      //resets the timer
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
