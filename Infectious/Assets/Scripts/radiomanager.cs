using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class radiomanager : MonoBehaviour
{
    public TextMeshProUGUI radiotext;
    [TextArea(2, 10)]
    public string[] radioD1;
    private bool finishLine;

    int lineCount = 0;
    // Update is called once per frame
    void Update()
    {
        
    }

    void RadioDay1()
    {
        finishLine = false;
        for (int i = 0; i < radioD1.Length; i++)
        {
            foreach (char c in radioD1[i].ToCharArray())
            {
                if (finishLine)
                {
                    //radiotext.text = "";
                    radiotext.text = radioD1[i];
                }
                else
                    radiotext.text += c;
            }
            if (Input.GetMouseButtonDown(0) && !finishLine)
            {
                finishLine = true;
            }
                //radiotext.text += "\n\n";
        }
    }
}
