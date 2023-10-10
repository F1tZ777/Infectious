using UnityEngine;
using UnityEditor;

public class GameTool : EditorWindow
{
    gamemanager GameManager;
    npcScript npcScript;
    int Score;
    int Day;
    GameObject NPC;
    GameObject ActiveNPC;
    int CurrentNPC;
    int NPCsThisDay;
    int diseaseType;
    int diseaseTab = 0;
    string[] disease = new string[] { "No Diesase", "Minor Cold", "Non Contagious", "Mega Disease", "Dehydration" };
    int NoDiesase = 25;
    int MinorCold = 15;
    int NonContagious = 20;
    int MegaDisease = 25;
    int Dehydration = 15;



    [MenuItem("Tools/GameTool")]
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
        CurrentNPC = GameManager.CurrentNPC;
        NPC = GameManager.NPC;
        ActiveNPC = GameManager.ActiveNPC;
        NPCsThisDay = GameManager.NPCsThisDay;

        npcScript = GameObject.FindGameObjectWithTag("NPC").GetComponent<npcScript>();
        diseaseType = npcScript.diseaseType;
        
        Score = EditorGUILayout.IntField("Current score", Score); //Currently not in use, score system still in development
        Day = EditorGUILayout.IntField("Move to Day", Day); //Currently not in use, day system still in development
        CurrentNPC = EditorGUILayout.IntField("Current NPC", CurrentNPC);
        diseaseTab = EditorGUILayout.Popup("Select next disease for NPC ", diseaseTab, disease);
        NoDiesase = EditorGUILayout.IntField("Probability (%) for No Disease", NoDiesase);
        MinorCold = EditorGUILayout.IntField("Probability (%) for Minor Cold", MinorCold);
        NonContagious = EditorGUILayout.IntField("Probability (%) for Non Contagious", NonContagious);
        MegaDisease = EditorGUILayout.IntField("Probability (%) for Mega Disease", MegaDisease);
        Dehydration = EditorGUILayout.IntField("Probability (%) for Dehydration ", Dehydration);


        if (GUILayout.Button("Next NPC"))
        {
            GameManager.NextNPC();
        }

        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Reset all values"))
        {
            Score = 0;
            Day = 1;
            CurrentNPC = GameManager.CurrentNPC = 1;
        }
        GUILayout.EndVertical();
    }
}