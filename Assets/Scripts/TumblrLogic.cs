using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumblrLogic : MonoBehaviour
{

    public RayController ray;
    public GameObject tumblrOn;
    public GameObject tumblrOff;
    bool isAggressive;

    // Update is called once per frame
    void Update()
    {
        isAggressive = ray.GetIsAggressive();
        if (isAggressive)
        {
            tumblrOn.SetActive(true);
            tumblrOff.SetActive(false);
        }
        else
        {
            tumblrOn.SetActive(false);
            tumblrOff.SetActive(true);
        }
        
    }
}
