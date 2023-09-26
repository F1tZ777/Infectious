using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject NPC;
    public GameObject ActiveNPC;
    public int NPCsThisDay=7;
    public int CurrentNPC=0;
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
        ActiveNPC = Instantiate(NPC);
        CurrentNPC++;
    }

    public void NextNPC(){
        if(CurrentNPC<NPCsThisDay){
            Destroy(ActiveNPC);
            spawnNPC();
    }
    }
}
