using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DachaController : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    private bool isHealed = false;
    private float missingHealth;
    private bool isDead;

    private void Start()
    {
        currentHealth = 50; // Устанавливаем на старте текущее здоровье равным максимальному
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

    private void Die()
    {
        Debug.Log("Game Over");
        currentHealth = 0;
        isDead = true;
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

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
