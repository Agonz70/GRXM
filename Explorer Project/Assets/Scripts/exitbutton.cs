using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class exitbutton : MonoBehaviour
{

    public Text exitText;
    private Color newExitColor;
    public bool eHover;

    private void Start()
    {
        newExitColor = exitText.color;
    }
    private void Update()
    {
        UIRaycast();
    }

    private void UIRaycast()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            newExitColor.a = 0.50f;
            exitText.color = newExitColor;
            // Play Audio
            eHover = true;
        }
        else
            eHover = false;
    }
}
