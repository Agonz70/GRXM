using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public Text time;
    public Text score;
    private int minutes, seconds;
    public int scoreValue;

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
        UpdateScore();
    }

    void UpdateTime()
    {
        minutes = (int)Mathf.Floor(Time.timeSinceLevelLoad / 60);
        seconds = (int)Time.timeSinceLevelLoad % 60;

        if (seconds > 9)
            time.text = minutes + ":" + seconds;
        else
            time.text = minutes + ":0" + seconds;
    }

    void UpdateScore()
    {
        scoreValue = minutes * 100 + seconds * 10/6;
        score.text = "" + scoreValue;
    }
}
