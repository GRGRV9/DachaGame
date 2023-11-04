using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{
    public float healingRate = 1;
    public float damageRate = 1;
    public DachaController dacha;
    public EnemyController enemy;
    bool dachaInRay = true;
    bool enemyInRay = false;

    private void Update()
    {
        if (dachaInRay)
        {
            dacha.Heal(healingRate);
        }
        if (enemyInRay)
        {
            enemy.DealDamage(damageRate);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dacha")
        {
            dachaInRay = false;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            enemyInRay = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dacha")
        {
            dachaInRay = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            enemyInRay = true;
            enemy = collision.gameObject.GetComponent<EnemyController>();
        }
    }
}
