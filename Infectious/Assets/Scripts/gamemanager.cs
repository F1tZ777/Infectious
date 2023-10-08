using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject NPC;
    public GameObject ActiveNPC;
    public Dialogue dialogueScript;
    public int NPCsThisDay=7;
    [HideInInspector]public int CurrentNPC=0;
    public GameObject toolkit;
    private int correctDetains;
    private int wrongfullyDetains;
    private int correctApproves;
    private int wrongfullyApproves;
    private int totalNPCs;
    [HideInInspector]public float performaceRange;
    [HideInInspector]public float wrongfullyDetainedPercentage;
    [HideInInspector]public float totalDetains;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnNPC();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnNPC(){
        //ActiveNPC = Instantiate(NPC);
        ActiveNPC.GetComponent<npcScript>().NextNPC(CurrentNPC);
        dialogueScript.StartDialogue();
        Debug.Log("CurrentNPC"+CurrentNPC);
        CurrentNPC++;
        //BroadcastMessage("NextNPCSpawned");
        toolkit.GetComponent<TestScriptsIntermediate>().NextNPCSpawnedBroadcast();
    }

    public void NextNPC(){
        if(CurrentNPC<NPCsThisDay){
            totalNPCs++;
            performaceRange=(float)(totalNPCs-wrongfullyApproves)/(float)totalNPCs;
            wrongfullyDetainedPercentage=(float)wrongfullyDetains/(float)totalNPCs;
            Debug.Log("Performance Range = " + performaceRange);
            Debug.Log("Wronfully Detained Percentage = " + wrongfullyDetainedPercentage);
            //Destroy(ActiveNPC);
            spawnNPC();
        }
    }

    public void Detain(){
        dialogueScript.DeniedDialogue();
        if(ActiveNPC.GetComponent<npcScript>().diseaseType==3){
            correctDetains++;
            totalDetains++;
            NextNPC();
        }
        else{
            wrongfullyDetains++;
            totalDetains++;
            NextNPC();
        }
        
    }
    public void Approve(){
        dialogueScript.AcceptedDialogue();
        if(ActiveNPC.GetComponent<npcScript>().diseaseType==3){
            wrongfullyApproves++;
            NextNPC();
        }
        else{
            correctApproves++;
            NextNPC();
        }
    }
}
