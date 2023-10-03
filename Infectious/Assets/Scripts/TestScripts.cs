using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScripts : MonoBehaviour
{
    public int symptomToCheck;
    private GameObject activeNPC;
    public GameObject gameManager;
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
        Debug.Log("Symptom " + symptomToCheck + "" + activeNPC.GetComponent<npcScript>().patientSymptomList[symptomToCheck]);
    }
    void NextNPCSpawned(){
        activeNPC = gameManager.GetComponent<gamemanager>().ActiveNPC;
    }
}
