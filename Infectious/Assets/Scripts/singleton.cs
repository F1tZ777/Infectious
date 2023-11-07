using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleton : MonoBehaviour
{
    public static singleton Instance;
    public int performanceScore;
    public int totalNPCs;
    public int totaldays=7;
    public int currentday=0;
    public int totalDetains;
    public float totalDetainPercentage;
    public float totalApprovePercentage;
    public float[] SymptomProbabiityShiftParty = new float[10]; 
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
}
