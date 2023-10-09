using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    public bool AssetReady;
    public GameObject UrineTestTrue;
    public GameObject UrineTestFalse;
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
        
        if(AssetReady==false){
        if(activeNPC.GetComponent<npcScript>().patientSymptomList[symptomToCheck]==true){
            testResultText.text = testResultTextTrue;
        }
        else{
            testResultText.text = testResultTextFalse;
        }
        Debug.Log("Symptom " + symptomToCheck + "" + activeNPC.GetComponent<npcScript>().patientSymptomList[symptomToCheck]);
        }
        else{
        if(activeNPC.GetComponent<npcScript>().patientSymptomList[symptomToCheck]==true){
            testResultText.text = "";
            UrineTestTrue.SetActive(true);
        }
        else{
            testResultText.text = "";
            UrineTestFalse.SetActive(true);
        }
    }
    }
    void NextNPCSpawned(){
        activeNPC = gameManager.GetComponent<gamemanager>().ActiveNPC;
    }

    void closemenu(){
        UrineTestTrue.SetActive(false);
        UrineTestFalse.SetActive(false);
    }
}
