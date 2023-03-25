using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    [SerializeField] private HealthBar healthBar;
    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }
    public void TakeDamage(float applyDamage)
    {
        currentHealth -= applyDamage;
        healthBar.UpdateHealthBar(maxHealth, currentHealth);
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
