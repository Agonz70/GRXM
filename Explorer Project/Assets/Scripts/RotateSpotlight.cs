using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpotlight : MonoBehaviour
{
    private Quaternion newRot;
    public float xRot, yRot, zRot;
    public float rotationSpeed;
    private bool moveRight = true;

    private void Start()
    {
        xRot = -20f;
        yRot = -60f;
        zRot = 7.262001f;
    }

    private void Update()
    {
        if (yRot > 80f)
        {
            moveRight = false;
        }
        else if (yRot < -100f )
        {
            moveRight = true;
        }

        if (!moveRight)
        {
            yRot -= rotationSpeed;
        }

        if (moveRight)
        {
            yRot += rotationSpeed;
        }
        newRot = Quaternion.Euler(xRot, yRot, zRot);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, newRot, 1f);
    }
}
