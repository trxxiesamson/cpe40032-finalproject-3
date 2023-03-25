using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupEffect : ScriptableObject
{
    // This is a scriptable object where we used this to create the health buff
    public abstract void Apply(GameObject target);
}
