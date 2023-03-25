using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    const float PotionLifespanSeconds = 10;
    Timer deathTimer; //span of potions


    void Start()
    { 
        // create and start timer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = PotionLifespanSeconds;
        deathTimer.Run(); 
    }

    // / Update is called once per frame
    void Update()
    {
        // destroy health potion if timer finished
        if(deathTimer){
            if (deathTimer.Finished)
            {    
                Destroy(gameObject);       
            }
        }
        
    }
    
}
