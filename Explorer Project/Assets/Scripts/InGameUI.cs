using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public float minutes;
    public float seconds;
    private bool menuPause = false;
    public Text time;
    public GameObject inGameMenu;
    public GameObject deathMenu;
    public GameObject winMenu;

    public bool success = false;

    void Update()
    {
        UpdateTime();
        InGameMenu();
    }

    void UpdateTime()
    {
        if (!success)
        {
            minutes = (int)Mathf.Floor(Time.timeSinceLevelLoad / 60);
            seconds = (int)Time.timeSinceLevelLoad % 60;
        }

        if (seconds < 10)
            time.text = "0" + minutes + ":0" + seconds;
        else if (seconds > 9 && seconds < 60)
            time.text = "0" + minutes + ":" + seconds;
        else if (seconds > 59)
            time.text = minutes + ":" + seconds;
    }

    private void InGameMenu()
    {
        if (!menuPause)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Time.timeScale = 0;
                menuPause = !menuPause;
                inGameMenu.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                inGameMenu.SetActive(false);
                Time.timeScale = 1;
                menuPause = !menuPause;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Go2MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Go2SplashScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Go2Level1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(4);
    }

    public void Go2Level2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(5);
    }

    public void Go2LevelScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
}
