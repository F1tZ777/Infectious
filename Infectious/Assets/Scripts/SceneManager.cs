using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{

    public Animator transition;
    public void startGame()
    {
        StartCoroutine(TransitionScene("MainLevel"));
    }

    public void GameQuit() {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void End()
    {
        StartCoroutine(TransitionScene("End"));
    }

    public void MainMenu()
    {
        StartCoroutine(TransitionScene("MainMenuDemo"));
    }

    IEnumerator TransitionScene(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }



}
