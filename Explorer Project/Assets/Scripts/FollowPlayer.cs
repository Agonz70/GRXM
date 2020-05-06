using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private Vector3 newPos;

    void Update()
    {
        if (player)
        {
            newPos = this.transform.position;
            newPos.x = player.transform.position.x;
            newPos.y = player.transform.position.y;
            this.transform.position = newPos;
        }
    }
}
