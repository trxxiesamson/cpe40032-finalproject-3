using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDamage : MonoBehaviour
{
    private Rigidbody golemRB;
    private int golemDamage = 20;
    // Start is called before the first frame update
    void Start()
    {
        golemRB = GetComponent<Rigidbody>(); // rigidbody for golem
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Player takes damage when golem attacks or collides
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Golem"))
            {
                Controller playerHealth = other.GetComponent<Controller>();
                playerHealth.TakeDamage(golemDamage);
            }      
            else if (gameObject.CompareTag("Golem"))
            {
                Controller playerHealth = other.GetComponent<Controller>();
                playerHealth.TakeDamage(golemDamage);
            }      
        }
    }
    
}
