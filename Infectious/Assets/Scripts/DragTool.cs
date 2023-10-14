using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTool : MonoBehaviour
{
    //private RectTransform rectTransform;
    public Vector2 originalPos;

    Vector3 mousePositionOffset;
    

    private void Awake()
    {
        //rectTransform = GetComponent<RectTransform>();

        originalPos = transform.localPosition;
    }

    private Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        mousePositionOffset = gameObject.transform.position - GetMousePosition();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePosition() + mousePositionOffset;
    }

    private void OnMouseUp()
    {
        transform.localPosition = originalPos;
    }

}
