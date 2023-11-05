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

    public SpriteRenderer sunSprite;
    public SpriteRenderer raySprite;
    private Color startSunColor;
    private Color aggressiveSunColor;
    private Color targetSunColor;
    private Color startRayColor;
    private Color aggressiveRayColor;
    private Color targetRayColor;
    public float colorChangeSpeed;

    private Vector3 startRayScale;
    private Vector3 aggressiveRayScale;
    private Vector3 targetRayScale;


    private void Start()
    {
        startSunColor = sunSprite.color;
        targetSunColor = startSunColor;

        startRayColor = raySprite.color;
        targetRayColor = startRayColor;

        aggressiveSunColor = new Color(1f, 0.2f, 0.2f, startSunColor.a);
        aggressiveRayColor = new Color(1f, 0.2f, 0.2f, startRayColor.a);

        startRayScale = transform.localScale;
        Debug.Log("Scale: " + startRayScale);
        aggressiveRayScale = new Vector3(0.4f, 0.75f, 1.0f);
        targetRayScale = startRayScale;
    }

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

        sunSprite.color = Color.Lerp(sunSprite.color, targetSunColor, Time.deltaTime * colorChangeSpeed);
        raySprite.color = Color.Lerp(raySprite.color, targetRayColor, Time.deltaTime * colorChangeSpeed);

        transform.localScale = Vector3.Lerp(transform.localScale, targetRayScale, Time.deltaTime * colorChangeSpeed);

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
        targetSunColor = aggressiveSunColor;
        targetRayColor = aggressiveRayColor;
        targetRayScale = aggressiveRayScale;
        StartCoroutine(StartSounds());
    }
    public void TurnAggressiveModeOff()
    {
        isAggressive = false;
        targetSunColor = startSunColor;
        targetRayColor = startRayColor;
        targetRayScale = startRayScale;
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
