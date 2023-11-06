using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public Sound[] music, sfx;
    public AudioSource musicSource, sfxSource;

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(music, z => z.name == name);

        if (s == null)
        {
            Debug.Log("Music not found");
        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    private void Start()
    {
        
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfx, z => z.name == name);

        if (s == null)
        {
            Debug.Log("SFX not found");
        }

        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
}
