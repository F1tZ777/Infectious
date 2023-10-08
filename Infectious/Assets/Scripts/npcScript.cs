using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour
{
    [HideInInspector]public int diseaseType;
    [SerializeField]private int NoOfDieseaseTypes;
    [SerializeField]private float []OddsForSymptomsNoDiesase = new float[10];
    [SerializeField]private float []OddsForSymptomsMinorCold = new float[10];
    [SerializeField]private float []OddsForSymptomsNonContagious = new float[10];
    [SerializeField]private float []OddsForSymptomsMegaDisease = new float[10];
    [SerializeField]private float []OddsForSymptomsDehydration = new float[10];
    [HideInInspector]public bool []patientSymptomList = new bool[10];
    [SerializeField]private int []patientDiseaseList;

    
    //[SerializeField]private float OddsForSymptoms;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextNPC(int NPCNum){
        InitializeNPC(patientDiseaseList[NPCNum]);
    }

    private void InitializeNPC(int disease){
        if(disease>0){
        InitializeDisease(disease-1);
        }
        else{
            diseaseType = Random.Range(0,NoOfDieseaseTypes);
        }
        Debug.Log("DiseaseType"+diseaseType);
    }

    private void InitializeDisease(int diseaseT){
        float []activeDiseaseOdds = new float[10];
        float DiseaseOddRan;
        switch(diseaseT){
            case 0: activeDiseaseOdds = OddsForSymptomsNoDiesase; break;
            case 1: activeDiseaseOdds = OddsForSymptomsMinorCold; break;
            case 2: activeDiseaseOdds = OddsForSymptomsNonContagious; break;
            case 3: activeDiseaseOdds = OddsForSymptomsMegaDisease; break;
            case 4: activeDiseaseOdds = OddsForSymptomsDehydration; break;
            default: Debug.Log("YOU FUCKED UP THE RANDOM RANGE FOR DISEASE TYPE"); break;
        }
        for(int i=0; i<10; i++){
            DiseaseOddRan = Random.Range(0.0f, 1.0f);
            if(DiseaseOddRan<=activeDiseaseOdds[i]){
                patientSymptomList[i]=true;
            }
            else{
                patientSymptomList[i]=false;
            }
        }
    }
}
