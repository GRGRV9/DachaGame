using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Скорость вращения объекта.

    private void Update()
    {
        // Получаем ввод с клавиатуры.
        float horizontalInput = Input.GetAxis("Horizontal");

        // Создаем вектор вращения на основе ввода.
        Vector3 rotation = new Vector3(0, 0, -horizontalInput);

        // Применяем вращение к объекту.
        transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
    }
}
