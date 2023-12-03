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
    [TextArea(2, 10)]
    public string badRebelEnd;
    [TextArea(2, 10)]
    public string goodRebelEnd;
    private string end;
    public Sprite goodEndSprite;
    public Sprite badEndSprite;
    public Sprite goodRebelEndSprite;
    public Sprite badRebelEndSprite;
    public Sprite arrestedEndSprite;
    public Sprite firedEndSprite;
    public SpriteRenderer pepelaugh;

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
        if (singleton.Instance.rebel)
            if (singleton.Instance.performanceScore > 0)
            {
                end = goodRebelEnd;
                pepelaugh.sprite = goodRebelEndSprite;
            }
            else
            {
                end = badRebelEnd;
                pepelaugh.sprite = badRebelEndSprite;
            }
        else if (singleton.Instance.rioted)
        {
            end = firedEnd;
            pepelaugh.sprite = firedEndSprite;
        }
        else if (singleton.Instance.wrongfullyApprovedPercentage >= 1.0f)
        {
            end = arrestedEnd;
            pepelaugh.sprite = arrestedEndSprite;
        }
        else
        {
            if (singleton.Instance.performanceScore > 0)
            {
                end = goodEnd;
                pepelaugh.sprite = goodEndSprite;
            }
            else
            {
                end = badEnd;
                pepelaugh.sprite = badEndSprite;
            }
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
