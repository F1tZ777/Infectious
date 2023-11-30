using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrineTest : MonoBehaviour
{
    public int symptomToCheck;
    public GameObject UrineDoc;
    public GameObject NormalUrine;
    public GameObject BloodyUrine;
    public GameObject[] ThingsToHide;
    public gamemanager gameManager;
    public Sprite Highlighted;
    public Sprite NormalSprite;
    public Vector2 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == gameManager.GetComponent<gamemanager>().ActiveNPC.name)
        {
            transform.localPosition = originalPos;
            UrineDoc.SetActive(true);
            if (gameManager.GetComponent<gamemanager>().patientSymptomList[symptomToCheck] == true)
            {
               BloodyUrine.SetActive(true);
            }
            else
            {
                NormalUrine.SetActive(true);
            }

            for (int i = 0; i < ThingsToHide.Length; i++)
            {
                ThingsToHide[i].SetActive(false);
            }

        }
    }
}
