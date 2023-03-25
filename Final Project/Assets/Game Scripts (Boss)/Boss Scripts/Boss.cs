using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    //variables
    public int health; // can be adjusted
    private float timeBtwDamage = 1.5f;

    //Boss Components
    public AudioSource lichSfx;
    public Slider healthBar;
    private Animator lichAnim;

    // Victory references
    public bool victoryGame = false;
    public VictoryScreen VictoryScreen;

    // Start is called before the first frame update
    void Start()
    {
        lichAnim = GetComponent<Animator>();
        playSound();    //plays the background audio (lich dialogues)
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health;   //setting the boss' health
        lichAnim.SetBool("hit", false);
        if (health <= 50)
        {
            lichAnim.SetTrigger("enraged");     //Going into Boss' second state 
        }

        if (health <= 0)
        {
            lichAnim.SetBool("death", true);    //Boss will die
        }

        // give the player some time to recover before taking more damage !
        if (timeBtwDamage > 0)
        {
            timeBtwDamage -= Time.deltaTime;    //Allows the boss to cast a spell every 1.5 s
        }

    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;     // Decreases the boss' health acccording to a certain spell damage
        if(health <= 0)
        {
            lichAnim.SetTrigger("death");
            GetComponent<Collider>().enabled = false;
            victoryGame = true;
            FindObjectOfType<SoundEffects>().VictorySound();
            // FindObjectOfType<VictoryPlayer>().VictorySound();
            VictoryScreen.Victory(); // Activates the victory screen
            Debug.Log("VICTORY");
            Time.timeScale = 0f;

        }
        else
        {
            AudioManager.instance.Play("SlimeDamage");      //Used the same sfx for slime Damage for every kind of damage
            lichAnim.SetBool("hit", true);
        }
    }
    public void playSound()
    {
        lichSfx.enabled = true;
    }
}
