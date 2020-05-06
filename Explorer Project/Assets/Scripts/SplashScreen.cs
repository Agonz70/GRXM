using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{

    private void Update()
    {
        float rValue = Random.value;
        if (rValue < 0.01f)
        {
            this.gameObject.GetComponent<Light>().intensity = 0f;
        }
        else
        {
            this.gameObject.GetComponent<Light>().intensity = 17f;
        }
    }

    public void Go2MenuScene()
    {
        SceneManager.LoadScene(1);
    }

}
