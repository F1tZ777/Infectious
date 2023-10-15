using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class XRay : MonoBehaviour
{
    public float time = 20.0f;
    Vector3 mousePosOffset;
    //public TextMeshProUGUI timer;
    //public GameObject image;

    private Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Awake()
    {
        mousePosOffset = gameObject.transform.position - GetMousePosition();
        //image.SetActive(true);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePosition() + mousePosOffset;
    }

    private void Update()
    {
        transform.position = GetMousePosition() + mousePosOffset;
        //time -= Time.deltaTime;
        //timer.text = time.ToString();
        //if (Input.GetMouseButtonDown(1) || time <= 0.0f)
        //{
        //    Destroy(gameObject);
        //    image.SetActive(false);
        //}
    }
}
