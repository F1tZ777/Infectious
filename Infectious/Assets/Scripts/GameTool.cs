using UnityEngine;
using UnityEditor;

public class GameTool : EditorWindow
{
    gamemanager GameManager;
    int Score;
    int Day;
    GameObject NPC;
    GameObject ActiveNPC;
    int CurrentNPC;
    int NPCsThisDay;


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

        Score = EditorGUILayout.IntField("Current score", Score); //Currently not in use, score system still in development
        Day = EditorGUILayout.IntField("Move to Day", Day); //Currently not in use, day system still in development
        CurrentNPC = EditorGUILayout.IntField("Current NPC", CurrentNPC);

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