using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCastingSystem : MonoBehaviour
{
    //referencing another script (General Spell Behaviour)
   [SerializeField] private Spell spellToCast1;
   [SerializeField] private Spell spellToCast2;

    //Player's mana-centered values
   [SerializeField] private float maxMana = 100f;
   [SerializeField] private float currentMana;
   [SerializeField] private float manaRechargeRate = 2f;
   [SerializeField] private float timeBetweenCast = 0.25f;
    private float currentCastTimer;

    //Getting the casting points of the player
   [SerializeField] private Transform castPoint1;
   [SerializeField] private Transform castPoint2;

    //Referencing another scripts
   [SerializeField] private ManaBar manaBar;
   [SerializeField] private Controller sound;


    private bool isCastingMagic = false;

    private void Awake()
    {
        currentMana = maxMana;          //current mana is equal to max mana
        manaBar.UpdateManaBar(maxMana, currentMana);
    }
    private void Update()
    {
        bool hasEnoughMana1 = currentMana - spellToCast1.spellToCast.manaCost > 0f;     //checks when the spell has the required mana
        bool hasEnoughMana2 = currentMana - spellToCast2.spellToCast.manaCost > 0f;

        if (!isCastingMagic && Input.GetKeyDown(KeyCode.E) && hasEnoughMana1)           //won't let player instantiate the spell from cast point if there's no mana left
        {
            isCastingMagic = true;
            currentMana -= spellToCast1.spellToCast.manaCost;
            manaBar.UpdateManaBar(maxMana, currentMana);
            currentCastTimer = 0;
            CastSpell1();
            sound.FireSound();          //plays the fireball sfx
        }
        if (!isCastingMagic && Input.GetKeyDown(KeyCode.Q) && hasEnoughMana2)
        {
            isCastingMagic = true;
            currentMana -= spellToCast2.spellToCast.manaCost;
            manaBar.UpdateManaBar(maxMana, currentMana);
            currentCastTimer = 0;
            CastSpell2();
            sound.IceSound();       //plays the ice sfx
        }
        if (isCastingMagic)
        {
            currentCastTimer += Time.deltaTime;         //sets casting time for spells

            if (currentCastTimer > timeBetweenCast)
            {
                isCastingMagic = false;
            }
        }
        if (currentMana < maxMana && !isCastingMagic)
        {
            currentMana += manaRechargeRate * Time.deltaTime;           //recharges the mana lost
            manaBar.UpdateManaBar(maxMana, currentMana);
            if (currentMana > maxMana)
            {
                currentMana = maxMana;
            }
        }

    }
    void CastSpell1()       //instantiations
    {
        Instantiate(spellToCast1, castPoint1.position, castPoint1.rotation);
    }
    void CastSpell2()
    {
        Instantiate(spellToCast2, castPoint2.position, castPoint2.rotation);
    }
}
