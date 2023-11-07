using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    //public singleton singleton;

    private void Start()
    {
        if (PlayerPrefs.HasKey("masterVolume") || PlayerPrefs.HasKey("musicVolume") || PlayerPrefs.HasKey("sfxVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMasterVolume();
            SetMusicVolume();
            SetSFXVolume();
        }
            

        //if (PlayerPrefs.HasKey("musicVolume"))
        //{
        //    LoadMusicVolume();
        //}
        //else
        //    SetMusicVolume();

        //if (PlayerPrefs.HasKey("sfxVolume"))
        //{
        //    LoadSFXVolume();
        //}
        //else
        //    SetSFXVolume();
    }

    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        mixer.SetFloat("masterVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        mixer.SetFloat("musicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        mixer.SetFloat("sfxVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    void LoadVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");

        SetMasterVolume();
        SetMusicVolume();
        SetSFXVolume();
    }

    //void LoadMusicVolume()
    //{

    //}

    //void LoadSFXVolume()
    //{

    //}
}
