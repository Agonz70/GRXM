using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private InGameUI theUI;
    private bool tutorialPause = false;
    private float seconds;
    private float minutes;
    private bool firstCheck = true;
    private bool pausing = true;

    private void Start()
    {
        theUI = GetComponent<InGameUI>();
    }

    private void Update()
    {
        Demo();

        minutes = theUI.minutes;
        seconds = theUI.seconds;
    }

    private void Demo()
    {
        if (tutorialPause)
        {
            Time.timeScale = 0;
            
            if (pausing)
                StartCoroutine(DelayedText());
        }

        if(seconds == 1 && firstCheck)
        {
            tutorialPause = true;
            firstCheck = !firstCheck;
        }

        if(seconds == 3 && !firstCheck)
        {
            tutorialPause = true;
            firstCheck = !firstCheck;
        }

        if (seconds == 5 && firstCheck)
        {
            tutorialPause = true;
            firstCheck = !firstCheck;
        }

        if (seconds == 9 && !firstCheck)
        {
            tutorialPause = true;
            firstCheck = !firstCheck;
        }

        if (seconds == 11 && firstCheck)
        {
            tutorialPause = true;
            firstCheck = !firstCheck;
        }

        if (seconds == 15 && !firstCheck)
        {
            tutorialPause = true;
            firstCheck = !firstCheck;
        }

        if (seconds == 18 && firstCheck)
        {
            tutorialPause = true;
            firstCheck = !firstCheck;
        }
    }

    private IEnumerator DelayedText()
    {
        pausing = false;

        yield return new WaitForSecondsRealtime(2f);
        
        Time.timeScale = 1;
        tutorialPause = !tutorialPause;
        pausing = true;
    }


}
