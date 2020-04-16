using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMaster : MonoBehaviour
{
    public Canvas MainMenu;

    public void ExitApp()
    {
        SceneManager.LoadScene("Start Scene");
    }

    public void ContinueToGameScene()
    {
        SceneManager.LoadScene("Explorer Project");
    }
}
