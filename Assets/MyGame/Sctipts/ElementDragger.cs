using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElementDragger : EventTrigger
{
    private bool moving;

    private void Update()
    {
        if (moving)
        {
            Vector3 screenPoint = Input.mousePosition;

            transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        moving = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        moving = false;
    }
}
