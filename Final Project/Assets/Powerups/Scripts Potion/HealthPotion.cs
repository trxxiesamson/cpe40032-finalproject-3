using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public PowerupEffect powerupEffect;

    // When the Player collides with the potion, it will destroy it
    // And the player will regain health
    private void OnTriggerEnter(Collider collision)
    {
        // This checks the the object with the name Player and continues the execution program
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            powerupEffect.Apply(collision.gameObject);
        }
    }
}
