using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    
    public Animator transition;
    public void startGame()
    {
        StartCoroutine(TransitionScene("Radio"));
    }

    public void endDay()
    {
        StartCoroutine(TransitionScene("DayEnd"));
    }

    public void nextDay(){
        if(singleton.Instance.currentday<=singleton.Instance.totaldays){
            StartCoroutine(TransitionScene("Day"+singleton.Instance.currentday));
        }
        else
            End();
    }

    public void GameQuit() {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Radio()
    {
        StartCoroutine(TransitionScene("Radio"));
    }

    public void Ending()
    {
        StartCoroutine(TransitionScene("Ending"));
    }

    public void End()
    {
        StartCoroutine(TransitionScene("End"));
    }

    public void MainMenu()
    {
        singleton.Instance.resetVar();

        StartCoroutine(TransitionScene("MainMenuDemo"));
    }

    public IEnumerator TransitionScene(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }



}
