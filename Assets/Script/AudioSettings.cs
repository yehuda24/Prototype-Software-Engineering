using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;

    private const string MusicPref = "MusicVolume";
    private const string SFXPref = "SFXVolume";

    void Start()
    {
        // Load saved volume settings or set default values
        if (PlayerPrefs.HasKey(MusicPref))
        {
            float savedMusicVolume = PlayerPrefs.GetFloat(MusicPref);
            musicSlider.value = savedMusicVolume;
            audioMixer.SetFloat("BGMVolume", savedMusicVolume);
        }
        else
        {
            // Set default volume level
            musicSlider.value = 0.75f;
            audioMixer.SetFloat("BGMVolume", 0.75f);
        }

        if (PlayerPrefs.HasKey(SFXPref))
        {
            float savedSFXVolume = PlayerPrefs.GetFloat(SFXPref);
            sfxSlider.value = savedSFXVolume;
            audioMixer.SetFloat("SFXVolume", savedSFXVolume);
        }
        else
        {
            // Set default volume level
            sfxSlider.value = 0.75f;
            audioMixer.SetFloat("SFXVolume", 0.75f);
        }

        // Add listeners to save volume when sliders are changed
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("BGMVolume", volume);
        PlayerPrefs.SetFloat(MusicPref, volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
        PlayerPrefs.SetFloat(SFXPref, volume);
    }
}
