using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DachaController : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public float frostDamage = 100;
    private bool isHealed = false;
    private bool isDamaged;
    private bool isFrostDamaged;
    private float missingHealth;
    private bool isDead;
    private bool isFrosted = true;
    private Coroutine frostRoutine;

    public GameObject snowIcon;

    private void Start()
    {
        currentHealth = maxHealth; // Устанавливаем на старте текущее здоровье равным максимальному
        isDead = false;
        snowIcon.SetActive(false);
        frostRoutine = StartCoroutine(Frosting());
    }

    private void Update()
    {
        if (isFrosted)
        {
            snowIcon.SetActive(true);
            DealRateFrostDamage(frostDamage);
        }
        else
        {
            snowIcon.SetActive(false);
        }
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

    public void DealRateFrostDamage(float damageCount)
    {
        if (isFrostDamaged == false)
        {
            StartCoroutine(FrostDamageCoroutine(damageCount));
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
        StopCoroutine(frostRoutine);

        isFrosted = false;
        isHealed = true;
        missingHealth = maxHealth - currentHealth;
        healCount = healCount / 10;
        if (missingHealth >= healCount)
        {
            currentHealth += healCount;
        }
        else
        {
            healCount = missingHealth;
            currentHealth += healCount;
        }
        yield return new WaitForSeconds(0.1f);
        isHealed = false;
        frostRoutine = StartCoroutine(Frosting());

    }

    IEnumerator DamageCoroutine(float damageCount)
    {
        StopCoroutine(frostRoutine);
        isFrosted = false;
        isDamaged = true;

        if (currentHealth < damageCount)
        {
            currentHealth -= currentHealth;
        }
        else
        {
            damageCount = damageCount / 10;
            currentHealth -= damageCount;
        }
        if (currentHealth <= 0)
        {
            Die();
        }

        yield return new WaitForSeconds(0.1f); // продолжить примерно через 100ms
        isDamaged = false;
        frostRoutine = StartCoroutine(Frosting());
    }

    IEnumerator FrostDamageCoroutine(float damageCount)
    {
        isFrostDamaged = true;

        if (currentHealth < damageCount)
        {
            currentHealth -= currentHealth;
        }
        else
        {
            damageCount = damageCount / 10;
            currentHealth -= damageCount;
        }
        if (currentHealth <= 0)
        {
            Die();
        }

        yield return new WaitForSeconds(0.1f);
        isFrostDamaged = false;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    IEnumerator Frosting()
    {
        Debug.Log("Frosting: 5");
        yield return new WaitForSeconds(1f);
        Debug.Log("Frosting: 4");
        yield return new WaitForSeconds(1f);
        Debug.Log("Frosting: 3");
        yield return new WaitForSeconds(1f);
        Debug.Log("Frosting: 2");
        yield return new WaitForSeconds(1f);
        Debug.Log("Frosting: 1");
        yield return new WaitForSeconds(1f);
        isFrosted = true;
    }
}
