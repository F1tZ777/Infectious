using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{

    public SceneManager SceneManager;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            SceneManager.MainMenu();
    }
}
