using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour
{
    public float healingRate = 1;
    public DachaController dacha;
    bool dachaInRay = true;

    private void Update()
    {
        if (dachaInRay)
        {
            dacha.Heal(healingRate);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dacha")
        {
            dachaInRay = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dacha")
        {
            dachaInRay = true;
        }
    }
}
