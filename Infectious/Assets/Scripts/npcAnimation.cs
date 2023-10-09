using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcAnimation : MonoBehaviour
{
    [HideInInspector]public Animator _anim;
    //string _currentState;
    
    

    private void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
    }

    public void ChangeAnimation(string newState)
    {
        /*if (newState == _currentState)
        {
            return;
        }*/

        _anim.Play(newState);

        //_currentState = newState;
    }

    public bool IsAnimationPlaying(Animator animator, string stateName)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 4.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
