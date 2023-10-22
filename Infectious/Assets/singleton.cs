using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleton : MonoBehaviour
{
    public static singleton Instance;
    public int performanceScore;
    public int totalNPCs;
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
        } 
    }
}
