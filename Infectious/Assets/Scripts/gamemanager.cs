using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using System.Runtime.CompilerServices;

public class gamemanager : MonoBehaviour
{
    public GameObject NPC;
    public GameObject ActiveNPC;
    public GameObject Boss;
    public Dialogue dialogueScript;
    public npcAnimation animator;
    public npcAnimation bossAnimator;
    public npcAnimation scriptedNPCAnimator;
    public XRayClick XRayClick;
    public int NPCsThisDay=7;
    [HideInInspector]public int CurrentNPC=0;
    public GameObject toolkit;
    public GameObject accept;
    public GameObject deny;
    public GameObject XRayIcon;
    public GameObject XRayUses;
    public TextMeshProUGUI textObject;
    private int correctDetains;
    private int wrongfullyDetains;
    private int correctApproves;
    private int wrongfullyApproves;
    private int totalNPCs;
    private bool entering;
    private Renderer NPCRender;
    //[SerializeField]private Renderer[] scriptedNPCRenderers;
    private Renderer BossRender;
    [HideInInspector]public float performaceRange;
    [HideInInspector]public float wrongfullyDetainedPercentage;
    [HideInInspector]public float totalDetains;
    public GameObject[] ScriptedNPC;
    public GameObject randomNPCs;
    public int[] NPCqueue;
    [SerializeField]private int []patientDiseaseList;
    private bool scriptedNPCvisible;

    const string ENTER = "NPCEnter";

    // Start is called before the first frame update
    void Start()
    {
        NPCRender = NPC.GetComponent<Renderer>();
        BossRender = Boss.GetComponent<Renderer>();
        /*for(int i=0;i<ScriptedNPC.Length;i++){
            scriptedNPCRenderers[i] = ScriptedNPC[i].GetComponent<Renderer>();
        }*/
        spawnNPC();
        textObject.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<ScriptedNPC.Length;i++){
            if(ScriptedNPC[i].GetComponent<Renderer>().isVisible){
                scriptedNPCvisible=true;
                }
            }
        if (animator.IsAnimationPlaying(animator._anim, ENTER) || animator.IsAnimationPlaying(animator._anim, "NPCAccept")
            || animator.IsAnimationPlaying(animator._anim, "NPCDeny") || animator.IsAnimationPlaying(bossAnimator._anim, "BossEnter") || animator.IsAnimationPlaying(scriptedNPCAnimator._anim, "ScriptedNPCEnter"))
        {
            toolkit.SetActive(false);
            accept.SetActive(false);
            deny.SetActive(false);
            XRayUses.SetActive(false);
        }
        else if (!NPCRender.isVisible && !BossRender.isVisible && !scriptedNPCvisible)
        {
            toolkit.SetActive(false);
            accept.SetActive(false);
            deny.SetActive(false);
            XRayUses.SetActive(false);
        }
        else
        {
            if (!entering)
            {
                if (NPCRender.isVisible||scriptedNPCvisible)
                {
                    scriptedNPCvisible=false;
                    toolkit.SetActive(true);
                    accept.SetActive(true);
                    deny.SetActive(true);
                    XRayUses.SetActive(true);
                    dialogueScript.StartDialogue();
                    entering = true;

                    if (XRayClick.uses > 0)
                    {
                        XRayClick.cooldown = false;
                        XRayClick.time = 20.0f;
                    }
                }
                else if (BossRender.isVisible)
                {
                    toolkit.SetActive(false);
                    accept.SetActive(false);
                    deny.SetActive(false);
                    XRayUses.SetActive(false);
                    dialogueScript.BossDialogue();
                    entering = true;
                }
            }
            //Debug.Log("jdkflsdjfkls");
        }
    }

    public void spawnNPC(){
        //ActiveNPC = Instantiate(NPC);
        if(NPCqueue[CurrentNPC]==0){
            ActiveNPC=randomNPCs;
            ActiveNPC.GetComponent<npcScript>().NextNPC(CurrentNPC,patientDiseaseList[CurrentNPC]);
            //animator.ChangeAnimation(ENTER);
            ActiveNPC.GetComponent<npcAnimation>().ChangeAnimation(ENTER);
        }
        else{
            ActiveNPC = ScriptedNPC[NPCqueue[CurrentNPC]-1];
            ActiveNPC.GetComponent<npcScript>().NextNPC(CurrentNPC,patientDiseaseList[CurrentNPC]);
            //scriptedNPCAnimator.ChangeAnimation("ScriptedNPCEnter");
            ActiveNPC.GetComponent<npcAnimation>().ChangeAnimation("ScriptedNPCEnter");
        }
        //dialogueScript.StartDialogue();
        Debug.Log("CurrentNPC"+CurrentNPC);
        Debug.Log(NPCqueue[CurrentNPC]);
        Debug.Log(ActiveNPC);
        CurrentNPC++;
        //BroadcastMessage("NextNPCSpawned");
        //toolkit.GetComponent<TestScriptsIntermediate>().NextNPCSpawnedBroadcast();
    }

    public void spawnBoss()
    {
        bossAnimator.ChangeAnimation("BossEnter");
    }

    public void NextNPC(){
        textObject.text = string.Empty;
        entering = false;
        if (CurrentNPC<NPCsThisDay){
            totalNPCs++;
            performaceRange=(float)(totalNPCs-wrongfullyApproves)/(float)totalNPCs;
            wrongfullyDetainedPercentage=(float)wrongfullyDetains/(float)totalNPCs;
            Debug.Log("Performance Range = " + performaceRange);
            Debug.Log("Wronfully Detained Percentage = " + wrongfullyDetainedPercentage);
            //Destroy(ActiveNPC);
            spawnNPC();
        }
        else
        {
            spawnBoss();
        }
    }

    public void Detain(){
        dialogueScript.DeniedDialogue();
        if(ActiveNPC.GetComponent<npcScript>().diseaseType==3){
            correctDetains++;
            totalDetains++;
        }
        else{
            wrongfullyDetains++;
            totalDetains++;
        }
        
    }
    public void Approve(){
        dialogueScript.AcceptedDialogue();
        if(ActiveNPC.GetComponent<npcScript>().diseaseType==3){
            wrongfullyApproves++;
        }
        else{
            correctApproves++;
        }
    }
}
