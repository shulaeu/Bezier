using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider))]

public class AnchorPoint : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private void OnMouseDown()
    {
        if (Camera.main == null)
        {
            return;
        }

        screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);

        offset = gameObject.transform.position - worldPoint;

        DisableJoysticks();
    }

    private void OnMouseUp()
    {
        EnableJoysticks();
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        if (Camera.main == null)
        {
            return;
        }
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    private void EnableJoysticks()
    {
        UIEventHelper.InvokeToggleJoystick(true);
    }

    private void DisableJoysticks()
    {
        UIEventHelper.InvokeToggleJoystick(false);
    }
}
