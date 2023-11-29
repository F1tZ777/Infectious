using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    public GameObject MouthScreen;
    public GameObject swabTest;
    public GameObject gameManager;
    public GameObject[] ThingsToHide;
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

    public void OnMouseOver()
    {
        transform.GetComponent<SpriteRenderer>().sprite = Highlighted;
        if (Input.GetMouseButton(0))
        {
            transform.GetComponent<SpriteRenderer>().sprite = NormalSprite;
        }
    }

    public void OnMouseExit()
    {
        transform.GetComponent<SpriteRenderer>().sprite = NormalSprite;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == gameManager.GetComponent<gamemanager>().ActiveNPC.name)
        {
            transform.localPosition = originalPos;
            MouthScreen.SetActive(true);
            swabTest.SetActive(true);
            for (int i = 0; i < ThingsToHide.Length; i++)
            {
                ThingsToHide[i].SetActive(false);
            }

        }
    }
}
