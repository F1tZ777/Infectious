using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calendar : MonoBehaviour
{
    public gamemanager gamemanager;
    public TextMeshProUGUI[] months;
    public TextMeshProUGUI[] days;
    // Start is called before the first frame update
    void Start()
    {
        if (singleton.Instance.currentday <= 5)
        {
            months[0].gameObject.SetActive(true);
            months[1].gameObject.SetActive(false);
        }
        else
        {
            months[0].gameObject.SetActive(false);
            months[1].gameObject.SetActive(true);
        }

        for(int i = 0; i < days.Length; i++)
        {
            days[i].gameObject.SetActive(false);
        }
        days[singleton.Instance.currentday - 1].gameObject.SetActive(true);
    }
}
