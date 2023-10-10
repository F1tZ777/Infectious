using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class npcAnimation : MonoBehaviour
{
    [HideInInspector]public Animator _anim;
    //string _currentState;
    
    

    private void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        /*if (IsAnimationPlaying(_anim, "NPCEnter"))
        {
            Debug.Log("YES");
        }
        else
            Debug.Log("NO");*/
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
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool AnimatorIsPlaying(string stateName)
    {
        /*return _anim.GetCurrentAnimatorStateInfo(0).length >
               _anim.GetCurrentAnimatorStateInfo(0).normalizedTime;*/
        return AnimationPlaying() && _anim.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    bool AnimationPlaying()
    {
        return _anim.GetCurrentAnimatorStateInfo(0).length >
               _anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
