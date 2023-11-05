using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    public float rotationSpeed = 45.0f; // Устанавливаем скорость вращения в градусах в секунду

    private void Start()
    {
        if (gameObject.transform.rotation.z < 0)
        {
            rotationSpeed = rotationSpeed * -1;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
    }

    void Update()
    {

        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime); // Вращаем объект вокруг своей оси по времени

    }
}
