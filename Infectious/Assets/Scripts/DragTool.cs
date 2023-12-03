using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTool : MonoBehaviour
{
    //private RectTransform rectTransform;
    public Vector2 originalPos;
    public float Timer = 0.07f;
    public Behaviour BC2D;
    Vector3 mousePositionOffset;
    private bool timerStart;

    private void Update()
    {
        if (timerStart)
        {
            Timer -= Time.deltaTime;
            if (Timer < 0f)
            {
                transform.localPosition = originalPos;
                Timer = 0.07f;
                timerStart = false;
            }
        }
    }

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
        BC2D.enabled = false;
        transform.position = GetMousePosition() + mousePositionOffset;
    }

    private void OnMouseUp()
    {
        BC2D.enabled = true;
        timerStart = true;
        //transform.localPosition = originalPos;
    }

}
