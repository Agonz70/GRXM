using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotKillCube : MonoBehaviour
{
    private Quaternion newRot;
    private float xRot = 0f, yRot = -45f, zRot = 0f;
    public float rotationSpeed;
    public GameObject particles;

    void Update()
    {
        xRot += rotationSpeed;
        yRot += rotationSpeed;
        //zRot += rotationSpeed;
        newRot = Quaternion.Euler(xRot, yRot, zRot);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, newRot, 1f);
        this.particles.transform.rotation = Quaternion.Slerp(this.particles.transform.rotation, newRot, 1f);
    }
}
