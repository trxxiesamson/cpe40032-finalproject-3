using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Golem : MonoBehaviour
{
    // Golem HP
    private int HP = 300;
    public AudioSource golemWalk;

    // For Golem health bar
    public Slider healthBar;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        // Updating healthbar value if Golem gets hit by the player
        healthBar.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            // Play death animation with sound effect
            ManageAudio.instance.Play("GolemDeath");
            animator.SetTrigger("Death");
            GetComponent<Collider>().enabled = false;
            golemWalk.enabled = false;
            Destroy(gameObject);
        }
        else
        { 
            // Play 'Get Hit' animation with sound effect
            ManageAudio.instance.Play("GolemHit");
            animator.SetTrigger("Damage");
            golemWalk.enabled = true;
        }
        
    }


}

