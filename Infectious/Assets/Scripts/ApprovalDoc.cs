using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApprovalDoc : MonoBehaviour
{
    [HideInInspector] public Animator animation;
    // Start is called before the first frame update
    void Start()
    {
        animation = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
