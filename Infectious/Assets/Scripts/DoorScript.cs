using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public SceneManager SceneManager;
    public Color normalColor, hoverColor, pressedColor;
    private SpriteRenderer rend;
    public Sprite DoorClose;
    public Sprite DoorOpen;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        //rend.color = hoverColor;
    }

    private void OnMouseOver()
    {
        transform.GetComponent<SpriteRenderer>().sprite = DoorOpen;
    }
    private void OnMouseDown()
    {
        //rend.color = pressedColor;
        Debug.Log("Pressed");
        /*if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Released");
            rend.color = normalColor;
            SceneManager.startGame();
        }*/
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Released");
        //rend.color = normalColor;
        SceneManager.startGame();
    }

    private void OnMouseExit()
    {
        transform.GetComponent<SpriteRenderer>().sprite = DoorClose;
        //rend.color = normalColor;
    }
}
