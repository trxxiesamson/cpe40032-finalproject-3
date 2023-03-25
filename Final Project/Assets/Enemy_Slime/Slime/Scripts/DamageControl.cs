using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour
{
    private Rigidbody slimeRB;
    private int slimeDamage = 10; // attack damage of turtle shell (slime)

    // Start is called before the first frame update
    void Start()
    {
        slimeRB = GetComponent<Rigidbody>(); //Gets a rigidbody for the slime
    }

    // Update is called once per frame
    void Update()
    {

    }
    // This is for when the GameObject with the tag "Player"
    // collides with the slime when it gets attacked
    // slimeDamage will affect the player's health
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            if (gameObject.CompareTag("EnemySlime"))
            {
                Controller playerHealth = other.GetComponent<Controller>();
                playerHealth.TakeDamage(slimeDamage);
            }
            else if (gameObject.CompareTag("EnemySlime"))
            {
                Controller playerHealth = other.GetComponent<Controller>();
                playerHealth.TakeDamage(slimeDamage);
            }
        }
    }
    
}
