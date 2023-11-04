using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        enemyController = gameObject.GetComponent<EnemyController>();
        textMeshPro = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = enemyController.GetCurrentHealth().ToString();
    }
}
