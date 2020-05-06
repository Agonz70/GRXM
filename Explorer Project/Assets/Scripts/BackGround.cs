using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float randomMoveSpeed = 0.2f;
    public GameObject[] defaultBack;
    public GameObject[] greenBack;
    float waitTime;
    Vector3 movingBack;

    private void Start()
    {
        StartCoroutine(Glitch());
        movingBack = new Vector3(randomMoveSpeed, 0f, 0f);
    }

    private void Update()
    {
        if (Random.value < 0.1f)
        {
            for (int i = 0; i < defaultBack.Length; i++)
            {
                if (Random.value < 0.5f)
                {
                    defaultBack[i].transform.position = Vector3.Lerp(defaultBack[i].transform.position, defaultBack[i].transform.position + movingBack, 1f);
                    greenBack[i].transform.position = Vector3.Lerp(greenBack[i].transform.position, greenBack[i].transform.position + movingBack, 1f);
                }
                else
                {
                    defaultBack[i].transform.position = Vector3.Lerp(defaultBack[i].transform.position, defaultBack[i].transform.position - movingBack, 1f);
                    greenBack[i].transform.position = Vector3.Lerp(greenBack[i].transform.position, greenBack[i].transform.position - movingBack, 1f);
                }
            }
        }
    }

    public IEnumerator Glitch()
    {
        waitTime = Random.Range(0.2f, 2f);

        yield return new WaitForSeconds(waitTime * 10f);

        for (int i = 0; i < defaultBack.Length; i++)
        {
            if (Random.value < 0.5f)
            {
                greenBack[i].GetComponentInChildren<MeshRenderer>().enabled = true;
            }   
        }

        yield return new WaitForSeconds(waitTime);

        for (int i = 0; i < defaultBack.Length; i++)
        {
            greenBack[i].GetComponentInChildren<MeshRenderer>().enabled = false;
        }

        StartCoroutine(Glitch());

    }
}
