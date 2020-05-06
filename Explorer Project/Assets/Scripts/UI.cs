using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

    private startbutton startB;
    private infobutton infoB;
    private exitbutton exitB;
    private AudioScript audioManager;
    private bool oneShotAudio;

    private int minutes;
    private int seconds;

    private void Start()
    {
        titleColor = title.color;
        startColor = start.color;
        infoColor = info.color;
        exitColor = exit.color;
        startB = GetComponentInChildren<startbutton>();
        infoB = GetComponentInChildren<infobutton>();
        exitB = GetComponentInChildren<exitbutton>();
        audioManager = GetComponent<AudioScript>();
    }

    private void Update()
    {
        TextFade();

        if (startB.sHover && oneShotAudio)
        {
            audioManager.playSound();
            oneShotAudio = false;
        }
        if (!startB.sHover)
        {
            oneShotAudio = true;
        }
            
    }

    private void TextFade()
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

        if (rValue > 0.01f && rValue < 0.015f && !startB.sHover)
        {
            startColor.a = 0.2f;
            start.color = startColor;
        }
        else if (rValue > 0.015f && rValue < 0.02f && !infoB.iHover)
        {
            infoColor.a = 0.2f;
            info.color = infoColor;
        }
        else if (rValue > 0.02f && rValue < 0.025f && !exitB.eHover)
        {
            exitColor.a = 0.2f;
            exit.color = exitColor;
        }
        else if (rValue > 0.025f)
        {
            if (!startB.sHover)
            {
                startColor.a = 0.3215686f;
                start.color = startColor;
            }

            if (!infoB.iHover)
            {
                infoColor.a = 0.3215686f;
                info.color = infoColor;
            }

            if (!exitB.eHover)
            {
                exitColor.a = 0.3215686f;
                exit.color = exitColor;
            }
        }
    }
}
