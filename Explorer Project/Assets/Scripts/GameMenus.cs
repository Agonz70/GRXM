using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenus : MonoBehaviour
{
    public void Go2MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void Go2LevelScene()
    {
        SceneManager.LoadScene(2);
    }

    public void Go2SplashScene()
    {
        SceneManager.LoadScene(0);
    }

    public void Go2Level0()
    {
        SceneManager.LoadScene(3);
    }

    public void Go2Level1()
    {
        SceneManager.LoadScene(4);
    }
        
    public void Go2Level2()
    {
        SceneManager.LoadScene(5);
    }

    public void Go2InfoScene()
    {
        SceneManager.LoadScene(6);
    }
}
