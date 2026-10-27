using System;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolumeMaster(float volume)
    {
        SettingsData.masterVolume = volume;
        volume = Mathf.Log10(volume) * 20;
        audioMixer.SetFloat("Volume", volume);
        
    }

    public void SetVolumeMusic(float volume)
    {
        SettingsData.musicVolume = volume;
        volume = Mathf.Log10(volume) * 20;
        audioMixer.SetFloat("Music", volume);
        
    }

    public void SetVolumeAmbience(float volume)
    {
        SettingsData.ambienceVolume = volume;
        volume = Mathf.Log10(volume) * 20;
        audioMixer.SetFloat("Ambience", volume);
        
    }

    public void SetVolumeSFX(float volume)
    {
        SettingsData.effectsVolume = volume;
        volume = Mathf.Log10(volume) * 20;
        audioMixer.SetFloat("Effects", volume);
        
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        SettingsData.qualityIndex = qualityIndex;
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        SettingsData.isFullScreen = isFullScreen;
    }
}
