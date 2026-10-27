using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public AudioClip musicClip;
    public AudioClip ambienceClip;

    public SettingsMenu settings;

    void Start()
    {
        // Llamamos al AudioManager
        AudioManager.Instance.PlayMusic(musicClip, 0.5f);
        AudioManager.Instance.PlayAmbiance(ambienceClip, 0.4f);
        
        settings.SetVolumeMaster(SettingsData.masterVolume);
        settings.SetVolumeMusic(SettingsData.musicVolume);
        settings.SetVolumeAmbience(SettingsData.ambienceVolume);
        settings.SetVolumeSFX(SettingsData.effectsVolume);

        settings.SetQuality(SettingsData.qualityIndex);

        settings.SetFullScreen(SettingsData.isFullScreen);
    }




}