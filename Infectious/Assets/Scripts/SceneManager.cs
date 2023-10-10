using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void startGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainLevel");
    }

    public void Quit() {
        Application.Quit();
    }



}
