using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class daymanager : MonoBehaviour
{
    public SceneManager sceneManager;
    public audiomanager audiomanager;
    public singleton singleton;
    public TextMeshProUGUI daytext;
    // Start is called before the first frame update
    void Start()
    {
        audiomanager.PlaySFX("DayEnd");
        daytext.text = "Day " + singleton.currentday.ToString() + " Completed!";
        StartCoroutine(DayEnd());
    }

    IEnumerator DayEnd()
    {
        yield return new WaitForSeconds(10);
        sceneManager.nextDay();
        singleton.Instance.currentday++;
    }
}
