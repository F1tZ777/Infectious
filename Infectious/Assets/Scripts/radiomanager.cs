using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class radiomanager : MonoBehaviour
{
    public singleton singleton;
    public SceneManager sceneManager;
    public TextMeshProUGUI radiotext;
    [TextArea(2, 10)]
    public string[] radioD1;
    [TextArea(2, 10)]
    public string[] radioD2;
    [TextArea(2, 10)]
    public string[] radioD3;
    private string[] radio = new string[4];
    private bool finishLine;

    int lineCount = 0;
    int day;
    // Update is called once per frame
    void Start()
    {
        day = singleton.currentday;
        Debug.Log(singleton.Instance.currentday);
        radiotext.text = "";
        for (int i = 0; i < radio.Length; i++)
        {
            radio[i] = "";
        }
        if (singleton.Instance.currentday == 1)
        {
            for(int i = 0; i < radioD1.Length; i++)
            {
                radio[i] = radioD1[i];
            }
            StartCoroutine(RadioTextWrite());
        }
        else if (singleton.Instance.currentday == 2)
        {
            for (int i = 0; i < radioD2.Length; i++)
            {
                radio[i] = radioD2[i];
            }
            StartCoroutine(RadioTextWrite());
        }
        else if (singleton.Instance.currentday == 3)
        {
            for (int i = 0; i < radioD3.Length; i++)
            {
                radio[i] = radioD3[i];
            }
            StartCoroutine(RadioTextWrite());
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(radiotext.text == radio[lineCount])
                NextLine();
            else
            {
                StopAllCoroutines();
                radiotext.text = radio[lineCount];
            }
        }
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
