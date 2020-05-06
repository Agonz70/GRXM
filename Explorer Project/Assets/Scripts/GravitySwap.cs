using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwap : MonoBehaviour
{

    public void GravitySwapUpdate(Vector3[] moveDirections)
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Physics.gravity = new Vector2(-9.81f, 0f);
            //LeftMove();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Physics.gravity = new Vector2(0f, -9.81f);
            //DownMove();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Physics.gravity = new Vector2(0f, 9.81f);
            //UpMove();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Physics.gravity = new Vector2(9.81f, 0f);
            //RightMove();
        }
    }

    private void LeftMove()
    {

    }
}
