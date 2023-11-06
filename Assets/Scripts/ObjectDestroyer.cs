using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfSestroy());
    }

    IEnumerator SelfSestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
