using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class radiomanager : MonoBehaviour
{
    public singleton singleton;
    public SceneManager sceneManager;
    public audiomanager audiomanager;
    public TextMeshProUGUI radiotext;
    [TextArea(2, 10)]
    public string[] radioD1;
    [TextArea(2, 10)]
    public string[] radioD2;
    [TextArea(2, 10)]
    public string[] radioD3;
    private string[] radio = new string[4];
    private bool finishTuning;

    int lineCount = 0;
    int day;
    // Update is called once per frame
    void Start()
    {
        audiomanager.PlaySFX("RadioDial");
        radiotext.text = "";
        //for (int i = 0; i < radio.Length; i++)
        //{
        //    radio[i] = "";
        //}
        StartCoroutine(WaitForSFX());
    }

    void Update()
    {
        if(finishTuning)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (radiotext.text == radio[lineCount])
                    NextLine();
                else
                {
                    StopAllCoroutines();
                    radiotext.text = radio[lineCount];
                }
            }
        }
    }

    IEnumerator WaitForSFX()
    {
        yield return new WaitForSeconds(5.8f);
        audiomanager.PlayMusic("RadioStatic");
        yield return new WaitForSeconds(0.2f);
        InitializeRadioArr();
    }
    void InitializeRadioArr()
    {
        finishTuning = true;
        if (singleton.Instance.currentday == 1)
        {
            for (int i = 0; i < radioD1.Length; i++)
            {
                radio[i] = radioD1[i];
            }
        }
        else if (singleton.Instance.currentday == 2)
        {
            for (int i = 0; i < radioD2.Length; i++)
            {
                radio[i] = radioD2[i];
            }
        }
        else if (singleton.Instance.currentday == 3)
        {
            for (int i = 0; i < radioD3.Length; i++)
            {
                radio[i] = radioD3[i];
            }
        }
        StartCoroutine(RadioTextWrite());
    }

    IEnumerator RadioTextWrite()
    {
        foreach (char c in radio[lineCount].ToCharArray())
        {
            radiotext.text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void NextLine()
    {
        if(lineCount < radio.Length - 1)
        {
            radiotext.text = "";
            lineCount++;
            StartCoroutine(RadioTextWrite());
        }
        else
        {
            sceneManager.nextDay();
        }
    }

}
