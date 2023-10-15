using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class XRayClick : MonoBehaviour
{
    public GameObject XRay;
    public GameObject instantiatedObj;
    public float time = 20.0f;
    public TextMeshProUGUI timer;
    public GameObject image;
    private bool timeStart;

    private void OnMouseDown()
    {
        instantiatedObj = (GameObject) Instantiate(XRay);
        image.SetActive(true);
        timeStart = true;
    }

    private void Update()
    {
        if (timeStart) {
            time -= Time.deltaTime;
            timer.text = time.ToString();
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(instantiatedObj);
                image.SetActive(false);
                timeStart = false;
            }
            if (time <= 0.0f)
            {
                Destroy(instantiatedObj);
                image.SetActive(false);
                time = 0.0f;
            }
        }
    }
}
