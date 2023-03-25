using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HealthPotion")]
public class HealthBuff : PowerupEffect
{
    public float amount;

    // This applies the Health Potion effect upon being obtained by the player
    // The Controller script from the player is referenced here and the healthBar.value which is the HP
    public override void Apply(GameObject target)
    {
        target.GetComponent<Controller>().HP += amount; 
    }
}
