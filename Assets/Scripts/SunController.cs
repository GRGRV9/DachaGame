using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // �������� �������� �������.

    private void Update()
    {
        // �������� ���� � ����������.
        float horizontalInput = Input.GetAxis("Horizontal");

        // ������� ������ �������� �� ������ �����.
        Vector3 rotation = new Vector3(0, 0, -horizontalInput);

        // ��������� �������� � �������.
        transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
    }
}
