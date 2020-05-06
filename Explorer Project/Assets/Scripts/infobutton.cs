using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class infobutton : MonoBehaviour
{

    public Text infoText;
    private Color newInfoColor;
    public bool iHover;

    private void Start()
    {
        newInfoColor = infoText.color;
    }
    private void Update()
    {
        UIRaycast();
    }

    private void UIRaycast()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            newInfoColor.a = 0.50f;
            infoText.color = newInfoColor;
            // Play Audio
            iHover = true;
        }
        else
            iHover = false;
    }
}
