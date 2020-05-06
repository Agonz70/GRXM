using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Quaternion rot;
    public int forceApplied = 47000;
    private JumpSound jumpSound;
    public float rotationSpeed = 5f;
    public float raycastDist = 0.6f;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        jumpSound = GetComponentInChildren<JumpSound>();
    }

    public void DownJump()
    {
        if (Physics.Raycast(transform.position, Vector3.down, GetComponent<BoxCollider>().size.y/2 + raycastDist))
        {
            rot = transform.rotation;
            rot.z = Mathf.Round(rot.z / 90) * 90;
            transform.rotation = rot;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidBody.velocity = Vector3.zero;
                rigidBody.AddForce(Vector2.up * forceApplied);
                jumpSound.playSound();
            }
        }
        else
        {
            transform.Rotate(Vector3.back * rotationSpeed);
        } 
    }

    public void LeftJump()
    {
        if (Physics.Raycast(transform.position, Vector3.right, GetComponent<BoxCollider>().size.y / 2 + raycastDist))
        {
            rot = transform.rotation;
            rot.z = Mathf.Round(rot.z / 90) * 270; //TODO
            transform.rotation = rot;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidBody.velocity = Vector3.zero;
                rigidBody.AddForce(Vector2.left * forceApplied);
                jumpSound.playSound();
            }
        }
        else
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
    }

    public void UpJump()
    {
        if (Physics.Raycast(transform.position, Vector3.up, GetComponent<BoxCollider>().size.y / 2 + raycastDist))
        {
            rot = transform.rotation;
            rot.z = Mathf.Round(rot.z / 90) * 90 + 180;
            transform.rotation = rot;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidBody.velocity = Vector3.zero;
                rigidBody.AddForce(Vector2.down * forceApplied);
                jumpSound.playSound();
            }
        }
        else
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
    }

    public void RightJump()
    {
        if (Physics.Raycast(transform.position, Vector3.left, GetComponent<BoxCollider>().size.y / 2 + raycastDist))
        {
            rot = transform.rotation;
            rot.z = Mathf.Round(rot.z / 90) * 90 + 90; //TODO
            transform.rotation = rot;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidBody.velocity = Vector3.zero;
                rigidBody.AddForce(Vector2.right * forceApplied);
                jumpSound.playSound();
            }
        }
        else
        {
            transform.Rotate(Vector3.back * rotationSpeed);
        }
    }
}
