using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Endings : MonoBehaviour
{
    public singleton singleton;
    public SceneManager sceneManager;
    public audiomanager audiomanager;
    public TextMeshProUGUI endingtext;
    [TextArea(2, 10)]
    public string goodEnd;
    [TextArea(2, 10)]
    public string badEnd;
    [TextArea(2, 10)]
    public string firedEnd;
    [TextArea(2, 10)]
    public string arrestedEnd;
    private string end;

    int lineCount;
    // Start is called before the first frame update
    void Start()
    {
        endingtext.text = "";
        InitializeEndArr();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (endingtext.text == end)
                sceneManager.End();
        }
    }

    void InitializeEndArr()
    {
        if (singleton.Instance.totalDetainPercentage == 1)
            end = firedEnd;
        else if (singleton.Instance.totalApprovePercentage == 1)
            end = arrestedEnd;
        else
        {
            if (singleton.Instance.performanceScore > 0)
                end = goodEnd;
            else
                end = badEnd;
        }
        StartCoroutine(EndTextWrite());
    }

    IEnumerator EndTextWrite()
    {
        foreach (char c in end.ToCharArray())
        {
            endingtext.text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    //void NextLine()
    //{
    //    if (lineCount < end.Length - 1)
    //    {
    //        endingtext.text = "";
    //        lineCount++;
    //        StartCoroutine(EndTextWrite());
    //    }
    //    else
    //    {
    //        ;
    //    }
    //}
}
