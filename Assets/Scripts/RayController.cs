using UnityEngine;

public class RayController : MonoBehaviour
{
    public float healingRate = 1;
    public float damageRate = 1;
    public DachaController dacha;
    public EnemyController enemy;
    bool dachaInRay = true;
    bool enemyInRay = false;
    bool isAggressive = false;

    private void Update()
    {
        if (dachaInRay)
        {
            if (isAggressive == false)
            {
                dacha.Heal(healingRate);
            }
            else
            {
                dacha.DealRateDamage(damageRate);
            }

        }
        if (enemyInRay)
        {
            if (isAggressive == true)
            {
                enemy.DealDamage(damageRate);
            }
        }
        if (Input.GetKeyDown("space"))
        {
            ChangeAggressionMode();
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

    public void ChangeAggressionMode()
    {
        if (isAggressive == false)
        {
            TurnAggressiveModeOn();
        }
        else
        {
            TurnAggressiveModeOff();
        }
        Debug.Log(isAggressive);
    }

    public void TurnAggressiveModeOn()
    {
        isAggressive = true;
    }
    public void TurnAggressiveModeOff()
    {
        isAggressive = false;
    }
}
