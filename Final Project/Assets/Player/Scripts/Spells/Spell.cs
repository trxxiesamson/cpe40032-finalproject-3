using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Spell : MonoBehaviour
{
    //referencing another script
    public SpellScriptableObject spellToCast;
    public ParticleSystem hitEffect = null;

    //spells component
    private SphereCollider spellCollider;
    private Rigidbody spellRb;

    private void Awake()
    {
        spellCollider = GetComponent<SphereCollider>();
        spellCollider.isTrigger = true;
        spellCollider.radius = spellToCast.spellRadius;     //getting the spell's radius that is in another script

        spellRb = GetComponent<Rigidbody>();
        spellRb.isKinematic = true;

        Destroy(this.gameObject, spellToCast.lifetime);     //destroys the spell when it reaches its lifetime (declared from another script)
    }
    void Update()
    {
        if (spellToCast.speed > 0)      //fires the spell according to its speed(depends since it can be changed per spell)
        {
            transform.Translate(Vector3.forward * spellToCast.speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        if (other.gameObject.CompareTag("EnemySlime"))          //damages slime
        {
            transform.parent = other.transform;
            EnemySlime enemyslime_health = other.GetComponent<EnemySlime>();
            enemyslime_health.TakeDamage(20);
        }

        if (other.gameObject.CompareTag("Golem"))          //damages golem
        {
            transform.parent = other.transform;
            Golem golemHealth = other.GetComponent<Golem>();
            golemHealth.TakeDamage(30);
        }

        if (other.gameObject.CompareTag("Boss"))                // damages the boss
        {
            transform.parent = other.transform;
            Boss bossHealth = other.GetComponent<Boss>();
            bossHealth.TakeDamage(spellToCast.damageAmount);
        }
    }
}
