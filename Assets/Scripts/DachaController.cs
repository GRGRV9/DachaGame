using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DachaController : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    private bool isHealed = false;
    private bool isDamaged;
    private float missingHealth;
    private bool isDead;

    private void Start()
    {
        currentHealth = maxHealth; // Устанавливаем на старте текущее здоровье равным максимальному
        isDead = false;
    }
    public void Heal(float healCount)
    {
        if (isHealed == false && isDead == false)
        {
            StartCoroutine(HealCoroutine(healCount));
        }
    }
    public void DealDamage(float damageCount)
    {
        currentHealth -= damageCount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void DealRateDamage(float damageCount)
    {
        if (isDamaged == false)
        {
            StartCoroutine(DamageCoroutine(damageCount));
        }
    }

    private void Die()
    {
        Debug.Log("Game Over");
        currentHealth = 0;
        isDead = true;
        Time.timeScale = 0;
        Destroy(gameObject);
    }

    IEnumerator HealCoroutine(float healCount)
    {
        isHealed = true;
        missingHealth = maxHealth - currentHealth;
        if (missingHealth >= healCount)
        {
            currentHealth += healCount;
        }
        else
        {
            healCount = missingHealth;
            currentHealth += healCount;
        }
        Debug.Log("Dacha current health: " + currentHealth + " Damage count: " + healCount);
        yield return new WaitForSeconds(1f); // продолжить примерно через 100ms
        isHealed = false;
    }

    IEnumerator DamageCoroutine(float damageCount)
    {
        isDamaged = true;

        if (currentHealth < damageCount)
        {
            currentHealth -= currentHealth;
        }
        else
        {
            currentHealth -= damageCount;
        }
        Debug.Log("Dacha health: " + currentHealth + " Damage count: " + damageCount);
        if (currentHealth <= 0)
        {
            Die();
        }
        yield return new WaitForSeconds(0.1f); // продолжить примерно через 100ms
        isDamaged = false;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
