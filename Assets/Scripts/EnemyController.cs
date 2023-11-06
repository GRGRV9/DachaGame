using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;
    private EnemyController thisEnemyController;
    DachaController dacha;

    bool isDamaged;

    void Start()
    {
        currentHealth = maxHealth;
        thisEnemyController = gameObject.GetComponent<EnemyController>();

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
        GameObject.FindGameObjectWithTag("Ray").GetComponent<RayController>().DeleteFromEnemiesList(thisEnemyController);
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
        damageCount = damageCount / 10;

        if (currentHealth < damageCount)
        {
            currentHealth -= currentHealth;
        }
        else
        {            
            currentHealth -= damageCount;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
        
        yield return new WaitForSeconds(0.1f);
        isDamaged = false;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
