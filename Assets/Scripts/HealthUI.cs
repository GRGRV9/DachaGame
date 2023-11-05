using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Это public поле для TextMeshPro компонента.

    public DachaController dacha;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = dacha.GetCurrentHealth().ToString();
    }
}
