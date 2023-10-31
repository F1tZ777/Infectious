using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class XRayClick : MonoBehaviour
{
    public GameObject XRay;
    public GameObject instantiatedObj;
    public GameObject XRayIcon;
    public float time = 20.0f;
    public int uses = 2;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI amount;
    public GameObject image;
    public GameObject[] toolsToRemove;
    public bool cooldown;
    private bool timeStart;
    private bool inUse;

    private void Start()
    {
        amount.text = uses.ToString();
    }

    private void OnMouseDown()
    {
        if (!cooldown && !inUse)
        {
            inUse = true;
            instantiatedObj = (GameObject)Instantiate(XRay);
            image.SetActive(true);
            timeStart = true;
            for(int i = 0; i < toolsToRemove.Length; i++)
            {
                toolsToRemove[i].SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (timeStart) {
            time -= Time.deltaTime;
            int seconds = (int) (time % 60);
            timer.text = seconds.ToString() + "s";
            if (time <= 0.0f || Input.GetMouseButtonDown(1))
            {
                Destroy(instantiatedObj);
                image.SetActive(false);
                timeStart = false;
                time = 0.0f;
                uses -= 1;
                amount.text = uses.ToString();
                cooldown = true;
                for (int i = 0; i < toolsToRemove.Length; i++)
                {
                    toolsToRemove[i].SetActive(true);
                }
                inUse = false;
            }
            //if (time <= 0.0f)
            //{
            //    Destroy(instantiatedObj);
            //    image.SetActive(false);
            //    time = 0.0f;
            //    XRayIcon.SetActive(false);
            //}
        }
    }
}
