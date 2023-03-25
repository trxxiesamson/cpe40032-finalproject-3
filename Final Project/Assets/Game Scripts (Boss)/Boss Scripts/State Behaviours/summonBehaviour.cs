using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonBehaviour : StateMachineBehaviour
{
    //variables
    public float timer;
    public float minTime;
    public float maxTime;

    //for enemy spawning
    public GameObject[] enemies;
    public GameObject[] enemyClone;
    public Transform[] summonPoints;
    //private int randomEnemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        enemyClone[0] = Instantiate(enemies[0], summonPoints[0].transform.position, enemies[0].transform.rotation) as GameObject;   //spawn one enemy per attack
        //randomEnemy = Random.Range(0, enemies.Length);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)     //for boss to change into idle state
        {
            animator.SetTrigger("idle");
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
