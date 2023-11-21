using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleton : MonoBehaviour
{
    public static singleton Instance;
    public int performanceScore;
    public int totalNPCs;
    public int totaldays;
    public int currentday;
    public int totalDetains;
    public int wrongfullyDetains;
    public int wrongfullyApproves;
    public float totalDetainPercentage;
    public float totalApprovePercentage;
    public float wrongfullyDetainedPercentage;
    public float wrongfullyApprovedPercentage;
    public float[] SymptomProbabiityShiftParty = new float[10]; 
    [HideInInspector]public bool d5rebel=false, d6rebel=false, d7rebel=false;
    public bool riot;
    private void Awake() 
    { 
    // If there is an instance, and it's not me, delete myself.
    
    if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
    else 
        { 
        Instance = this;
        DontDestroyOnLoad(gameObject);
        } 
    }

    public void resetVar()
    {
        currentday = 1;
        performanceScore = 0;
        totalNPCs = 0;
        totalDetains = 0;
    }
}
