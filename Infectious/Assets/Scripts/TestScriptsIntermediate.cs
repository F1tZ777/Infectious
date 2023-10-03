using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptsIntermediate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextNPCSpawnedBroadcast(){
        BroadcastMessage("NextNPCSpawned");
    }
}
