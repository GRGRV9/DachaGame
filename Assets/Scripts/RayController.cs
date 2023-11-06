using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{
    public float healingRate;
    public float damageRate;
    public DachaController dacha;
    public List<EnemyController> enemiesList;
    bool dachaInRay = true;
    bool enemyInRay = false;
    bool isAggressive = false;
    bool isChangingMode = false;
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

    public GameObject strikeAnimation;
    private void Start()
    {
        startSunColor = sunSprite.color;
        targetSunColor = startSunColor;

        startRayColor = raySprite.color;
        targetRayColor = startRayColor;

        aggressiveSunColor = new Color(1f, 0.2f, 0.2f, startSunColor.a);
        aggressiveRayColor = new Color(1f, 0.2f, 0.2f, startRayColor.a);

        startRayScale = transform.localScale;
        aggressiveRayScale = new Vector3(0.4f, 0.75f, 1.0f);
        targetRayScale = startRayScale;

        idleRay.volume = 0f;
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

        if (isAggressive)
        {
            strikeAnimation.SetActive(true);
        }
        else
        {
            strikeAnimation.SetActive(false);
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
        if (isAggressive == false && isChangingMode == false)
        {
            TurnAggressiveModeOn();            
        }
        else if (isAggressive = true && isChangingMode == false)
        {
            TurnAggressiveModeOff();            
        }        
    }

    public void TurnAggressiveModeOn()
    {        
        colorChangeSpeed = 3;
        StartCoroutine(ChangeAggressiveModeWithDelay(colorChangeSpeed, true));
        targetSunColor = aggressiveSunColor;
        targetRayColor = aggressiveRayColor;
        targetRayScale = aggressiveRayScale;
        StartCoroutine(StartSounds());
    }
    public void TurnAggressiveModeOff()
    {
        colorChangeSpeed = 1;
        StopCoroutine(StartSounds());
        StartCoroutine(ChangeAggressiveModeWithDelay(colorChangeSpeed, false));        
        isAggressive = false;
        targetSunColor = startSunColor;
        targetRayColor = startRayColor;
        targetRayScale = startRayScale;
        idleRay.volume = 0f;
        startRay.Stop();
        stopRay.Play();
    }

    IEnumerator StartSounds()
    {
        stopRay.Stop();
        idleRay.volume = 0f;
        startRay.Play();
        yield return new WaitForSeconds(0.53f);
        idleRay.volume = 0.1f;
    }

    IEnumerator ChangeAggressiveModeWithDelay(float multiplier, bool mode)
    {
        isChangingMode = true;
        yield return new WaitForSeconds(1.5f / multiplier);
        isAggressive = mode;
        isChangingMode = false;
    }

    public void DeleteFromEnemiesList (EnemyController enemy)
    {
        enemiesList.Remove(enemy);
    }

    public bool GetIsAggressive()
    {
        return isAggressive;
    }
}
