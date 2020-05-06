using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFireSpawner : MonoBehaviour
{
    public GameObject firePrefab;
    public GameObject player;
    private float xPos, yPos, zPos;

    public void Start()
    {
        StartCoroutine(RandomPosition());
    }

    IEnumerator RandomPosition()
    {
        if (player)
        {
            xPos = player.transform.position.x + Random.Range(-5f, 5f);
            yPos = player.transform.position.y + Random.Range(6f, 10f);
            zPos = player.transform.position.z;
            Vector3 randomPos = new Vector3(xPos, yPos, zPos);

            GameObject fire = Instantiate(firePrefab, randomPos, Quaternion.identity);

            yield return new WaitForSeconds(2f);

            StartCoroutine(RandomPosition());
        }  
    }
}
