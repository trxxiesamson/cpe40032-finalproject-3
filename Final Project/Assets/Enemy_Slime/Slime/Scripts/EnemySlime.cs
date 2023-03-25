using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySlime : MonoBehaviour
{
    // references are here as well
    private int HP = 100; // Slime's health
    public Slider healthBar;
    public Animator animator;

    // extras (was not used)
    public GameObject slimeAttack;
    public Transform slimeAttack_Point;

    void Update()
    {
        healthBar.value = HP; // health bar value of the slime
    }

    // Plays the slime's attack audio
    public void Attack()
    {
        AudioManager.instance.Play("SlimeAttack");
    }

    // This is for the damage dealth by the Player to the slime
    // Animations in this line of code are triggered in the if statements
    public void TakeDamage(int damageAmount) 
    {
        HP-= damageAmount;
        if(HP<=0)
        {
            AudioManager.instance.Play("SlimeDeath");
            //Play Death anim
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject);
                

        }
        else
        {
            AudioManager.instance.Play("SlimeDamage");
            //Play Get Hit anim
            animator.SetTrigger("damage");
        }
    }
}
