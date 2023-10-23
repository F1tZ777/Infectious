using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookButtons : MonoBehaviour
{
    int pagePair = 0;
    public GameObject[] page;
    public GameObject next;
    public GameObject prev;

    public void NextPage()
    {
        if (pagePair == 0)
        {
            pagePair++;
            page[0].SetActive(false);
            page[1].SetActive(false);
            page[2].SetActive(true);
            page[3].SetActive(true);
            prev.SetActive(true);
        }

        else if (pagePair == 1)
        {
            pagePair++;
            page[2].SetActive(false);
            page[3].SetActive(false);
            page[4].SetActive(true);
            page[5].SetActive(true);
        }

        else if (pagePair == 2)
        {
            pagePair++;
            page[4].SetActive(false);
            page[5].SetActive(false);
            page[6].SetActive(true);
            next.SetActive(false);
        }
    }

    public void PrevPage()
    {
        if (pagePair == 3)
        {
            pagePair--;
            page[4].SetActive(true);
            page[5].SetActive(true);
            page[6].SetActive(false);
            next.SetActive(true);
        }

        else if (pagePair == 2)
        {
            pagePair--;
            page[2].SetActive(true);
            page[3].SetActive(true);
            page[4].SetActive(false);
            page[5].SetActive(false);
        }

        else if (pagePair == 1)
        {
            pagePair--;
            page[0].SetActive(true);
            page[1].SetActive(true);
            page[2].SetActive(false);
            page[3].SetActive(false);
            prev.SetActive(false);
        }
    }
}
