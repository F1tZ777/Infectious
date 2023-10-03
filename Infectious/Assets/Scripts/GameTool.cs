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
    int dieaseType;


    [MenuItem("Tools/GameTool")]
    public static void ShowWindow()
    {
        GetWindow(typeof(GameTool));
    }

    private void OnGUI()
    {
        
        GUILayout.Label("Testing Tools", EditorStyles.boldLabel);

        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<gamemanager>();
        CurrentNPC = GameManager.CurrentNPC;
        NPC = GameManager.NPC;
        ActiveNPC = GameManager.ActiveNPC;
        NPCsThisDay = GameManager.NPCsThisDay;

        npcScript = GameObject.FindGameObjectWithTag("NPC").GetComponent<npcScript>();
        dieaseType = npcScript.diseaseType; 

        Score = EditorGUILayout.IntField("Current score", Score); //Currently not in use, score system still in development
        Day = EditorGUILayout.IntField("Move to Day", Day); //Currently not in use, day system still in development
        CurrentNPC = EditorGUILayout.IntField("Current NPC", CurrentNPC);
        dieaseType = EditorGUILayout.IntField("dieaseType", dieaseType);


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
    }
}