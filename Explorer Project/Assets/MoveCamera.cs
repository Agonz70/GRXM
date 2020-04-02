using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject cameraM;
    public GameObject player;
    private Vector3 targetPosition;

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(player.transform.position.x, player.transform.position.y + 2.3f, player.transform.position.z - 2.7f);
        cameraM.transform.position = Vector3.Lerp(cameraM.transform.position, targetPosition, 1f);
    }
}
