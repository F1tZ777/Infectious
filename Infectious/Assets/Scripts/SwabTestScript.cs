using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwabTestScript : MonoBehaviour
{
    public int symptomToCheck;
    public GameObject gameManager;
    public Sprite HeavyMucus;
    public Sprite Healthy;
    public Sprite InMouth;
    public Sprite OriginalSprite;
    public Behaviour BC2D;
    public GameObject MouthScreen;
    public GameObject swabTest;
    public GameObject[] ThingsToShow;


    // Start is called before the first frame update
    void Start()
    {
        BC2D.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            transform.GetComponent<SpriteRenderer>().sprite = OriginalSprite;
            MouthScreen.SetActive(false);
            swabTest.SetActive(false);
            for (int i = 0; i < ThingsToShow.Length; i++)
            {
                ThingsToShow[i].SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(gameManager.GetComponent<gamemanager>().patientSymptomList[symptomToCheck] == true)
        {
            transform.GetComponent<SpriteRenderer>().sprite = HeavyMucus;
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().sprite = Healthy;
        }
    }

}

