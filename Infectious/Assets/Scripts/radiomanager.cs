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
    [TextArea(2, 10)]
    public string[] radioD4;
    [TextArea(2, 10)]
    public string[] radioD5;
    [TextArea(2, 10)]
    public string[] radioD6;
    [TextArea(2, 10)]
    public string[] radioD7;
    [TextArea(2, 10)]
    public string[] radioD6Rebel;
    [TextArea(2, 10)]
    public string[] radioD7Rebel;
    [TextArea(2, 10)]
    public string[] radioRiot;


    private string[] radio = new string[8];
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
        switch(singleton.Instance.currentday){
        case 1:
            for (int i = 0; i < radioD1.Length; i++)
            {
                radio[i] = radioD1[i];
            }
            break;
        
        case 2:
        
            for (int i = 0; i < radioD2.Length; i++)
            {
                radio[i] = radioD2[i];
            }
            break;
        
        case 3:
        
            for (int i = 0; i < radioD3.Length; i++)
            {
                radio[i] = radioD3[i];
            }
            break;

        case 4:
        
            for (int i = 0; i < radioD4.Length; i++)
            {
                radio[i] = radioD4[i];
            }
            break;

        case 5:
        
            for (int i = 0; i < radioD5.Length; i++)
            {
                radio[i] = radioD5[i];
            }
            break;

        case 6:
            if(singleton.Instance.rebel){
                for (int i = 0; i < radioD6Rebel.Length; i++)
                {
                radio[i] = radioD6Rebel[i];
                }
            }
            else{
                for (int i = 0; i < radioD6.Length; i++)
                {
                radio[i] = radioD6[i];
                }
            }
            if(singleton.Instance.riot){
                for (int i = radioD6.Length; i < radioD6.Length + radioRiot.Length; i++)
                {
                radio[i] = radioRiot[i-radioD6.Length];
                }
            }
            break;

        case 7:
            if(singleton.Instance.rebel){
                for (int i = 0; i < radioD7Rebel.Length; i++)
                {
                radio[i] = radioD7Rebel[i];
                }
                break;
            }
            else{
                for (int i = 0; i < radioD7.Length; i++)
                {
                radio[i] = radioD7[i];
                }
                break;
            }

        }
        StartCoroutine(RadioTextWrite());
    }
    

    IEnumerator RadioTextWrite()
    {
        foreach (char c in radio[lineCount].ToCharArray())
        {
            radiotext.text += c;
            yield return new WaitForSeconds(0.03f);
        }
    }

    void NextLine()
    {
        if(lineCount < radio.Length - 1&&radio[lineCount+1]!=null)
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
