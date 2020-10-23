using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotating : MonoBehaviour
{

    [SerializeField] float rotationAngle;
    [SerializeField] float rotationSpeed = 15;
    [SerializeField] Boolean rotationIsClockwise = true;

    void Update()
    {
        if (rotationIsClockwise)
        {
            rotationAngle -= Time.deltaTime * rotationSpeed;
        }
        else
        {
            rotationAngle += Time.deltaTime * rotationSpeed;
        }
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
    }
}
