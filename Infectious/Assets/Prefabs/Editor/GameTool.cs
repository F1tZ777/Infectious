using UnityEngine;
using UnityEditor;
using System.Diagnostics.CodeAnalysis;

public class GameTool : EditorWindow
{
    public gamemanager GameManager;
    public npcScript npcScript;
    public SceneManager sceneManager;
    public singleton singleton;
    public int Score;
    public int Day;
    public int CurrentNPC;
    public bool[] CurrentSymptoms;
    //public GameObject NPC;
    //public GameObject ActiveNPC;

    //public int NPCsThisDay;
    //public int diseaseType;
    //public int diseaseTab = 0;
    //public string[] disease = new string[] { "No Diesase", "Minor Cold", "Non Contagious", "Mega Disease", "Dehydration" };
    //public int NoDiesase = 25;
    //public int MinorCold = 15;
    //public int NonContagious = 20;
    //public int MegaDisease = 25;
    //public int Dehydration = 15;



    [MenuItem("Tools/Debugging Tool")]
    public static void ShowWindow()
    {
        GetWindow(typeof(GameTool));
    }

    private void OnGUI()
    {
        EditorGUIUtility.labelWidth = 200;
        GUILayout.BeginVertical();
        GUILayout.Label("Testing Tools", EditorStyles.boldLabel);
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<gamemanager>();
        npcScript = GameObject.FindGameObjectWithTag("NPC").GetComponent<npcScript>();
        sceneManager = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneManager>();
        singleton = GameObject.FindGameObjectWithTag("singleton").GetComponent<singleton>();
        Score = singleton.performanceScore;
        Day = singleton.currentday;
        CurrentSymptoms = npcScript.patientSymptomListREADONLYPLS;
        CurrentNPC = GameManager.CurrentNPC;
        //NPC = GameManager.NPC;
        //ActiveNPC = GameManager.ActiveNPC;
        //NPCsThisDay = GameManager.NPCsThisDay;
        //diseaseType = GameManager.diseaseType;


        Score = EditorGUILayout.IntField("Current score", Score); //Currently not in use, score system still in development
        Day = EditorGUILayout.IntField("Current day", Day); //Currently not in use, day system still in development
        CurrentNPC = EditorGUILayout.IntField("Current NPC", CurrentNPC);
        //CurrentSymptoms = EditorGUILayout.;
        //diseaseTab = EditorGUILayout.Popup("Select next disease for NPC ", diseaseTab, disease);
        //NoDiesase = EditorGUILayout.IntField("Probability (%) for No Disease", NoDiesase);
        //MinorCold = EditorGUILayout.IntField("Probability (%) for Minor Cold", MinorCold);
        //NonContagious = EditorGUILayout.IntField("Probability (%) for Non Contagious", NonContagious);
        //MegaDisease = EditorGUILayout.IntField("Probability (%) for Mega Disease", MegaDisease);
        //Dehydration = EditorGUILayout.IntField("Probability (%) for Dehydration ", Dehydration);


        if (GUILayout.Button("Cycle NPC Appearance"))
        {
            npcScript.RandomizerNPCAppearance();

        }

        if (GUILayout.Button("Next Day"))
        {
            singleton.Instance.currentday++;
            sceneManager.nextDay();
            sceneManager.TransitionScene("Day" + singleton.Instance.currentday);
        }

        if (GUILayout.Button("Restart Day"))
        {
            sceneManager.nextDay();
            sceneManager.TransitionScene("Day" + singleton.Instance.currentday);
        }

        GUILayout.EndVertical();
    }
}