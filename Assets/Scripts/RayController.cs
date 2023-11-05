using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{
    public float healingRate = 1;
    public float damageRate = 1;
    public DachaController dacha;
    public List<EnemyController> enemiesList;
    bool dachaInRay = true;
    bool enemyInRay = false;
    bool isAggressive = false;
    public AudioSource startRay;
    public AudioSource idleRay;
    public AudioSource stopRay;

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
                foreach (var enemy in enemiesList)
                {
                    enemy.DealDamage(damageRate);
                }
                
            }
        }
        if (Input.GetKeyDown("space"))
        {
            ChangeAggressionMode();
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
            enemiesList.Add(collision.gameObject.GetComponent<EnemyController>());
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
            enemiesList.Remove(collision.gameObject.GetComponent<EnemyController>());
            if (enemiesList.Count == 0)
            {
                enemyInRay = false;
            }
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
    }

    public void TurnAggressiveModeOn()
    {
        isAggressive = true;
        StartCoroutine(StartSounds());
    }
    public void TurnAggressiveModeOff()
    {
        isAggressive = false;
        idleRay.Stop();
        startRay.Stop();
        stopRay.Play();        
    }

    IEnumerator StartSounds()
    {
        stopRay.Stop();
        idleRay.Stop();
        startRay.Play();
        yield return new WaitForSeconds(2.17f);
        idleRay.Play();
    }
}
