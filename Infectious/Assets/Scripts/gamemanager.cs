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
    public npcAnimation animator;
    public int NPCsThisDay=7;
    [HideInInspector]public int CurrentNPC=0;
    public GameObject toolkit;
    public GameObject accept;
    public GameObject deny;
    public TextMeshProUGUI textObject;
    private int correctDetains;
    private int wrongfullyDetains;
    private int correctApproves;
    private int wrongfullyApproves;
    private int totalNPCs;
    private bool entering;
    private Renderer NPCRender;
    [HideInInspector]public float performaceRange;
    [HideInInspector]public float wrongfullyDetainedPercentage;
    [HideInInspector]public float totalDetains;

    const string ENTER = "NPCEnter";

    // Start is called before the first frame update
    void Start()
    {
        NPCRender = NPC.GetComponent<Renderer>();
        spawnNPC();
        textObject.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.IsAnimationPlaying(animator._anim, ENTER) || animator.IsAnimationPlaying(animator._anim, "NPCAccept")
            || animator.IsAnimationPlaying(animator._anim, "NPCDeny"))
        {
            Debug.Log("NO");
            toolkit.SetActive(false);
            accept.SetActive(false);
            deny.SetActive(false);
        }
        else if (!NPCRender.isVisible)
        {
            Debug.Log("Cannot see");
            toolkit.SetActive(false);
            accept.SetActive(false);
            deny.SetActive(false);
        }
        else
        {
            if (!entering)
            {
                Debug.Log("Dialoguing");
                toolkit.SetActive(true);
                accept.SetActive(true);
                deny.SetActive(true);
                dialogueScript.StartDialogue();
                entering = true;
            }

            else
                Debug.Log("YES");
        }
    }

    public void spawnNPC(){
        //ActiveNPC = Instantiate(NPC);
        ActiveNPC.GetComponent<npcScript>().NextNPC(CurrentNPC);
        //dialogueScript.StartDialogue();
        Debug.Log("CurrentNPC"+CurrentNPC);
        CurrentNPC++;
        //BroadcastMessage("NextNPCSpawned");
        toolkit.GetComponent<TestScriptsIntermediate>().NextNPCSpawnedBroadcast();
    }

    public void NextNPC(){
        if(CurrentNPC<NPCsThisDay){
            animator.ChangeAnimation(ENTER);
            entering = false;
            textObject.text = string.Empty;
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
            //NextNPC();
        }
        else{
            wrongfullyDetains++;
            totalDetains++;
            //NextNPC();
        }
        
    }
    public void Approve(){
        dialogueScript.AcceptedDialogue();
        if(ActiveNPC.GetComponent<npcScript>().diseaseType==3){
            wrongfullyApproves++;
            //NextNPC();
        }
        else{
            correctApproves++;
            //NextNPC();
        }
    }
}
