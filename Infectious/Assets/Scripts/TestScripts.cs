using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestScripts : MonoBehaviour
{
    public int symptomToCheck;
    private GameObject activeNPC;
    public GameObject gameManager;
    public GameObject TestPromt;
    public string testName;
    public string testResultTextTrue;
    public string testResultTextFalse;
    public TMP_Text testTitle;
    public TMP_Text testResultText;
    public GameObject Buttons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseUpAsButton()
    {
        transform.parent.gameObject.SetActive(false);
        Buttons.SetActive(false);
        TestPromt.SetActive(true);
        testTitle.text = testName;
        if(activeNPC.GetComponent<npcScript>().patientSymptomList[symptomToCheck]==true){
            testResultText.text = testResultTextTrue;
        }
        else{
            testResultText.text = testResultTextFalse;
        }
        Debug.Log("Symptom " + symptomToCheck + "" + activeNPC.GetComponent<npcScript>().patientSymptomList[symptomToCheck]);
    }
    void NextNPCSpawned(){
        activeNPC = gameManager.GetComponent<gamemanager>().ActiveNPC;
    }
}
