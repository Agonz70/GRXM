using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBackground : MonoBehaviour
{

    public Transform cam = null;
    public float xAmount = 1.0f, yAmount = 0.2f;

    private Vector2 newPos;
    private float x0, y0, xDiff, yDiff;

    private void Start()
    {
        x0 = cam.position.x;
        y0 = cam.position.y;
    }

    void Update()
    {
        xDiff = x0 + (cam.position.x * xAmount);
        yDiff = y0 + (cam.position.y * yAmount);
        newPos = new Vector2(cam.position.x - xDiff, cam.position.y - yDiff);
        transform.position = newPos;
    }
}
