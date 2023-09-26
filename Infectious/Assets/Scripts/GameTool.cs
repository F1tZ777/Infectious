using UnityEngine;
using UnityEditor;

public class GameTool : EditorWindow
{

    int Score;
    int Day;
    GameObject NPC;
    GameObject ActiveNPC;
    int CurrentNPC;


    [MenuItem("Tools/GameTool")]
    public static void ShowWindow()
    {
        GetWindow(typeof(GameTool));
    }

    private void OnGUI()
    {
        GUILayout.Label("Testing Tools", EditorStyles.boldLabel);
        Score = EditorGUILayout.IntField("Current score", Score);
        Day = EditorGUILayout.IntField("Move to Day", Day);

        if (GUILayout.Button("Next NPC"))
        {

        }
    }
}