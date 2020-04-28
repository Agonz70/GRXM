using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class startbutton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{

    public Text startText;
    private Color newStartColor;

    private void Start()
    {
        newStartColor = startText.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(eventData);
        newStartColor.a = 0.7f;
        startText.color = newStartColor;
        Debug.Log(startText.color);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData);
        newStartColor.a = 0.7f;
        startText.color = newStartColor;
        Debug.Log(startText.color);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log(eventData);
        newStartColor.a = 0.3215686f;
        startText.color = newStartColor;
    }
}
