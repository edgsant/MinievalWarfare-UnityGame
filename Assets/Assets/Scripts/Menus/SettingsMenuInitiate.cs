using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuInitiate : MonoBehaviour
{
    public Slider masterVolume;
    public Slider musicVolume;
    public Slider ambienceVolume;
    public Slider effectsVolume;

    public TMPro.TMP_Dropdown graphics;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        masterVolume.value = SettingsData.masterVolume;
        musicVolume.value = SettingsData.musicVolume;
        ambienceVolume.value = SettingsData.ambienceVolume;
        effectsVolume.value = SettingsData.effectsVolume;

        graphics.value = SettingsData.qualityIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
