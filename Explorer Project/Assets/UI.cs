using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text title;
    private Color titleColor;
    public Text start;
    private Color startColor;
    public Text info;
    private Color infoColor;
    public Text exit;
    private Color exitColor;

    private void Start()
    {
        titleColor = title.color;
        startColor = start.color;
        infoColor = info.color;
        exitColor = exit.color;
    }

    private void Update()
    {
        float rValue = Random.value;
        if (rValue < 0.01f)
        {
            titleColor.a = 0.7f;
            title.color = titleColor;
        }
        else
        {
            titleColor.a = 1f;
            title.color = titleColor;
        }

        if (rValue > 0.01f && rValue < 0.015f)
        {
            startColor.a = 0.2f;
            start.color = startColor;
        } 
        else if (rValue > 0.015f && rValue < 0.02f)
        {
            infoColor.a = 0.2f;
            info.color = infoColor;
        }
        else if (rValue > 0.02f && rValue < 0.025f)
        {
            exitColor.a = 0.2f;
            exit.color = exitColor;
        }
        else if (rValue > 0.025f)
        {
            startColor.a = 0.3215686f;
            infoColor.a = 0.3215686f;
            exitColor.a = 0.3215686f;
            start.color = startColor;
            info.color = infoColor;
            exit.color = exitColor;
        }
 

    }
}
