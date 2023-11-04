using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;
    DachaController dacha;

    bool isDamaged;
    float missingHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void DealDamage(float damageCount)
    {
        if (isDamaged == false)
        {
            StartCoroutine(DamageCoroutine(damageCount));
        }
    }

    private void Die()
    {
        var parentGameObject = transform.parent.gameObject;
        Destroy(parentGameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dacha")
        {
            dacha = collision.gameObject.GetComponent<DachaController>();
            dacha.DealDamage(currentHealth);
            Die();
        }
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
        Debug.Log("Enemy current health: " + currentHealth + " Damage count: " + damageCount);

        if (currentHealth <= 0)
        {
            Die();
        }
        yield return new WaitForSeconds(0.5f); // продолжить примерно через 100ms
        isDamaged = false;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
