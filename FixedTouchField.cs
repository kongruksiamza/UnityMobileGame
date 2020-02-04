using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedTouchField : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{

    [HideInInspector]
    public Vector2 touchdistance;
    [HideInInspector]
    public Vector2 pointbefore;
    [HideInInspector]
    protected int pointid;
    [HideInInspector]
    public bool pressed;

    void Update()
    {
        if (pressed)
        {
            if (pointid >= 0 && pointid < Input.touches.Length)
            {
                touchdistance = Input.touches[pointid].position - pointbefore;
                pointbefore = Input.touches[pointid].position;
            }
            else
            {
                touchdistance = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - pointbefore;
                pointbefore = Input.mousePosition;
            }
        }
        else
        {
            touchdistance = new Vector2();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
        pointid = eventData.pointid;
        pointbefore = eventData.position;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }
}
