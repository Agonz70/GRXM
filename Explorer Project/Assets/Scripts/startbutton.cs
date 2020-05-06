using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class startbutton : MonoBehaviour
{

    public Text startText;
    private Color newStartColor;
    public bool sHover;

    private void Start()
    {
        newStartColor = startText.color;
    }
    private void Update()
    {
        UIRaycast();
    }

    private void UIRaycast()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            newStartColor.a = 0.50f;
            startText.color = newStartColor;
            // Play Audio
            sHover = true;
        }
        else
            sHover = false;
    }
}
