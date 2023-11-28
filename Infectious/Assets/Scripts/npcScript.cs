using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour
{
    //[HideInInspector]public int diseaseType;
    /*[SerializeField]private float []OddsForSymptomsNoDiesase = new float[10];
    [SerializeField]private float []OddsForSymptomsMinorCold = new float[10];
    [SerializeField]private float []OddsForSymptomsNonContagious = new float[10];
    [SerializeField]private float []OddsForSymptomsMegaDisease = new float[10];
    [SerializeField]private float []OddsForSymptomsDehydration = new float[10];
    [HideInInspector]public bool []patientSymptomList = new bool[10];*/
    //[SerializeField]private int []patientDiseaseList;
    [SerializeField]private GameObject[] hair;
    [SerializeField]private GameObject []head;
    [SerializeField]private GameObject []eyes;
    [SerializeField]private GameObject []nose;
    [SerializeField]private GameObject []mouth;
    [SerializeField]private GameObject []body;
    
    private int gender;
    public bool scriptedNPC;
    public bool rebel;
    [HideInInspector]public bool []patientSymptomListREADONLYPLS;
    public AudioClip[] Cough;
    public AudioClip Sniff;
    public AudioClip FemaleBreath;
    public AudioClip MaleBreath;
    public AudioSource AudioSource;

    //[SerializeField]private float OddsForSymptoms;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        InvokeRepeating("PlayCoughSFX", 1.0f, Random.Range(25.0f, 30.0f));
        InvokeRepeating("PlayRunningNoseSFX", 1.0f, Random.Range(20.0f, 25.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void NextNPC(int patientdisease){
        InitializeNPC(patientdisease);
    }

    private void InitializeNPC(int disease){
        if(disease>0){
        diseaseType = disease-1;
        InitializeDisease(diseaseType);
        }
        else{
            //diseaseType = Random.Range(0,NoOfDieseaseTypes);
            //InitializeDisease(diseaseType);
            InitializeDisease(RandomizeDisease());
        }
        Debug.Log("DiseaseType"+diseaseType);
    }

    private void InitializeDisease(int diseaseT){
        float []activeDiseaseOdds = new float[10];
        switch(diseaseT){
            case 0: activeDiseaseOdds = OddsForSymptomsNoDiesase; break;
            case 1: activeDiseaseOdds = OddsForSymptomsMinorCold; break;
            case 2: activeDiseaseOdds = OddsForSymptomsNonContagious; break;
            case 3: activeDiseaseOdds = OddsForSymptomsMegaDisease; break;
            case 4: activeDiseaseOdds = OddsForSymptomsDehydration; break;
            default: Debug.Log("YOU FUCKED UP THE RANDOM RANGE FOR DISEASE TYPE"); break;
        }
        for(int i=0; i<10; i++){
            if(Random.Range(0.0f, 1.0f)<=activeDiseaseOdds[i]){
                patientSymptomList[i]=true;
            }
            else{
                patientSymptomList[i]=false;
            }
            //Debug.Log("Symptom"+i+" "+patientSymptomList[i]);
        }
        if(!scriptedNPC){
        RandomizerNPCAppearance();
        }
    }*/

    public void RandomizerNPCAppearance(){
        gender = Random.Range(0,2);
        //for (int i = 0; i < hair.Length; i++)
        //{
        //    hair[i].SetActive(false);
        //}
        for (int i=0; i<head.Length; i++){
            head[i].SetActive(false);
        }
        for(int i=0; i<eyes.Length; i++){
            eyes[i].SetActive(false);
        }
        for(int i=0; i<nose.Length; i++){
            nose[i].SetActive(false);
        }
        for(int i=0; i<mouth.Length; i++){
            mouth[i].SetActive(false);
        }
        for(int i=0; i<body.Length; i++){
            body[i].SetActive(false);
        }

        //if (gender == 0)
        //{
        //    hair[Random.Range(0,1)].SetActive(true);
        //}
        //else
        //{
        //    hair[Random.Range(2,3)].SetActive(true);
        //}

        if (gender==0){
            head[Random.Range(0,1)].SetActive(true);
        }
        else{
            head[2].SetActive(true);
        }

       
        if(patientSymptomListREADONLYPLS[6]==false){
            eyes[Random.Range(0,5)].SetActive(true);
        }
        else{
            eyes[Random.Range(5,10)].SetActive(true);
        }

        
        if(gender==0){
            nose[Random.Range(0, 2)].SetActive(true);
        }
        else if (patientSymptomListREADONLYPLS[7] == true && gender == 0)
        {
            nose[Random.Range(3, 5)].SetActive(true);
        }
        else
        {
            nose[Random.Range(6,7)].SetActive(true);
        }

        mouth[Random.Range(0,5)].SetActive(true);


        if(gender==0){
            body[Random.Range(0, 2)].SetActive(true);
        }
        else{
            body[3].SetActive(true);
        }

       

        
    }

    public void PlayCoughSFX()
    {
            if (patientSymptomListREADONLYPLS[0] == true && gender == 0)
            {
                AudioSource.clip = Cough[Random.Range(0, 1)];
                AudioSource.Play();
            }
            else if (patientSymptomListREADONLYPLS[0] == true && gender == 1)
            {
                AudioSource.clip = Cough[2];
                AudioSource.Play();
            }
    }

    public void PlayRunningNoseSFX()
    {
        if (patientSymptomListREADONLYPLS[2] == true)
        {
            AudioSource.clip = Sniff;
            AudioSource.Play();
        }
    }
}

