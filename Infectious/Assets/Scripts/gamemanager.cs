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
    [HideInInspector] public int NPCsThisDay;
    [HideInInspector] public int CurrentNPC = 0;
    public int days;
    public GameObject toolkit;
    public GameObject accept;
    public GameObject deny;
    public GameObject XRayIcon;
    public GameObject XRayUses;
    public TextMeshProUGUI textObject;
    public TMP_InputField notesText;
    private int correctDetains;
    private int wrongfullyDetains;
    private int correctApproves;
    private int wrongfullyApproves;
    //private int totalNPCs;
    private bool entering;
    private Renderer NPCRender;
    //[SerializeField]private Renderer[] scriptedNPCRenderers;
    private Renderer BossRender;
    [HideInInspector] public float performaceRange;
    //[HideInInspector]public int performanceScore;
    [HideInInspector] public float wrongfullyDetainedPercentage;
    [HideInInspector] public float totalDetains;
    public GameObject[] ScriptedNPC;
    public GameObject randomNPCs;
    public int[] NPCqueue;
    [SerializeField] private int[] patientDiseaseList;
    private bool scriptedNPCvisible;
    public GameObject singleton;
    public GameObject sceneManager;
    public int[] oddsForEachDiesease = new int[5];
    [SerializeField] private float[] OddsForSymptomsNoDiesase = new float[10];
    [SerializeField] private float[] OddsForSymptomsMinorCold = new float[10];
    [SerializeField] private float[] OddsForSymptomsNonContagious = new float[10];
    [SerializeField] private float[] OddsForSymptomsMegaDisease = new float[10];
    [SerializeField] private float[] OddsForSymptomsDehydration = new float[10];
    [HideInInspector] public bool[] patientSymptomList = new bool[10];
    [HideInInspector] public int diseaseType;



    const string ENTER = "NPCEnter";

    // Start is called before the first frame update
    void Start()
    {
        days = singleton.GetComponent<singleton>().days;
        NPCsThisDay = NPCqueue.Length;
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
        for (int i = 0; i < ScriptedNPC.Length; i++)
        {
            if (ScriptedNPC[i].GetComponent<Renderer>().isVisible)
            {
                scriptedNPCvisible = true;
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
                if (NPCRender.isVisible || scriptedNPCvisible)
                {
                    scriptedNPCvisible = false;
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

    public void spawnNPC()
    {
        //ActiveNPC = Instantiate(NPC);
        if (NPCqueue[CurrentNPC] == 0)
        {
            ActiveNPC = randomNPCs;
            InitializeNPC(patientDiseaseList[CurrentNPC]);
            //animator.ChangeAnimation(ENTER);
            ActiveNPC.GetComponent<npcAnimation>().ChangeAnimation(ENTER);
        }
        else
        {
            ActiveNPC = ScriptedNPC[NPCqueue[CurrentNPC] - 1];
            InitializeNPC(patientDiseaseList[CurrentNPC]);
            //scriptedNPCAnimator.ChangeAnimation("ScriptedNPCEnter");
            ActiveNPC.GetComponent<npcAnimation>().ChangeAnimation("ScriptedNPCEnter");
        }
        //dialogueScript.StartDialogue();
        Debug.Log("CurrentNPC" + CurrentNPC);
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

    public void NextNPC()
    {
        textObject.text = string.Empty;
        notesText.text = string.Empty;
        entering = false;
        if (CurrentNPC < NPCsThisDay)
        {
            singleton.GetComponent<singleton>().totalNPCs++;
            performaceRange = (float)(singleton.GetComponent<singleton>().totalNPCs - wrongfullyApproves) / (float)singleton.GetComponent<singleton>().totalNPCs;
            wrongfullyDetainedPercentage = (float)wrongfullyDetains / (float)singleton.GetComponent<singleton>().totalNPCs;
            Debug.Log("Performance Range = " + performaceRange);
            Debug.Log("Wronfully Detained Percentage = " + wrongfullyDetainedPercentage);
            //Destroy(ActiveNPC);
            spawnNPC();
        }
        else
        {
            singleton.GetComponent<singleton>().days++;
            sceneManager.GetComponent<SceneManager>().startGame();
        }
    }

    public void Detain()
    {
        dialogueScript.DeniedDialogue();
        if (diseaseType == 3)
        {
            correctDetains++;
            totalDetains++;
            singleton.GetComponent<singleton>().performanceScore += 2;
        }
        else
        {
            wrongfullyDetains++;
            totalDetains++;
        }

    }
    public void Approve()
    {
        dialogueScript.AcceptedDialogue();
        if (diseaseType == 3)
        {
            wrongfullyApproves++;
            singleton.GetComponent<singleton>().performanceScore -= 5;
        }
        else
        {
            correctApproves++;
            singleton.GetComponent<singleton>().performanceScore += 1;
        }
    }

    private void InitializeNPC(int disease)
    {
        if (disease > 0)
        {
            diseaseType = disease - 1;
        }
        else
        {
            //diseaseType = Random.Range(0,NoOfDieseaseTypes);
            //InitializeDisease(diseaseType);
            diseaseType = RandomizeDisease();
        }
        InitializeDisease(diseaseType);
        Debug.Log("DiseaseType " + diseaseType);
    }

    private void InitializeDisease(int diseaseT)
    {
        float[] activeDiseaseOdds = new float[10];
        switch (diseaseT)
        {
            case 0: activeDiseaseOdds = OddsForSymptomsNoDiesase; break;
            case 1: activeDiseaseOdds = OddsForSymptomsMinorCold; break;
            case 2: activeDiseaseOdds = OddsForSymptomsNonContagious; break;
            case 3: activeDiseaseOdds = OddsForSymptomsMegaDisease; break;
            case 4: activeDiseaseOdds = OddsForSymptomsDehydration; break;
            default: Debug.Log("YOU FUCKED UP THE RANDOM RANGE FOR DISEASE TYPE"); break;
        }
        for (int i = 0; i < 10; i++)
        {
            if (Random.Range(0.0f, 1.0f) <= activeDiseaseOdds[i])
            {
                patientSymptomList[i] = true;
            }
            else
            {
                patientSymptomList[i] = false;
            }
        }
        ActiveNPC.GetComponent<npcScript>().patientSymptomListREADONLYPLS = patientSymptomList;
        if (!ActiveNPC.GetComponent<npcScript>().scriptedNPC)
        {
            ActiveNPC.GetComponent<npcScript>().RandomizerNPCAppearance();
        }

    }
    private int RandomizeDisease()
    {
        int pool = 0;
        for (int i = 0; i < oddsForEachDiesease.Length; i++)
        {
            pool += oddsForEachDiesease[i];
        }
        int rand = Random.Range(0, pool);
        for (int i = 0; i < oddsForEachDiesease.Length; i++)
        {
            if (rand < oddsForEachDiesease[i])
            {
                oddsForEachDiesease[i]--;
                return i;
            }
            else
            {
                rand -= oddsForEachDiesease[i];
            }

        }
        return 5;
    }
}

    
