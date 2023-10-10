using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestScripts : MonoBehaviour
{
    public int symptomToCheck;
    public GameObject activeNPC;
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
    public Sprite HighlightedSprite;
    public Sprite NormalSprite;
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
        transform.GetComponent<SpriteRenderer>().sprite = NormalSprite;
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
        
        Debug.Log("Symptom " + symptomToCheck + "" + activeNPC.GetComponent<npcScript>().patientSymptomList[symptomToCheck]);
    }
    void NextNPCSpawned(){
        activeNPC = gameManager.GetComponent<gamemanager>().ActiveNPC;
    }
    public void closemenu(){
        UrineTestTrue.SetActive(false);
        UrineTestFalse.SetActive(false);
    }

    public void OnMouseOver()
    {
        transform.GetComponent<SpriteRenderer>().sprite = HighlightedSprite;
    }

    public void OnMouseExit()
    {
        transform.GetComponent<SpriteRenderer>().sprite = NormalSprite;
    }
}
