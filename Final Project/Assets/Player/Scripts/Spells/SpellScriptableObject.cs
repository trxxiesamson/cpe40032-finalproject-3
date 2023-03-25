using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells")]      //creates a new menu to create a spell with these values below (editable per spell)
public class SpellScriptableObject : ScriptableObject
{
    public int damageAmount = 10;
    public float manaCost = 5f;
    public float lifetime = 2f;
    public float speed = 10f;
    public float spellRadius = 0.5f;
}
