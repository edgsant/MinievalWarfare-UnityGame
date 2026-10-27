using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioSource AmbianceSource; // Nuevo: para el bosque/viento
    public AudioSource EffectsSource;

    public static AudioManager Instance = null;

    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of AudioManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        //Set AudioManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);


    }

    // Para efectos rápidos (tropas, oro, muerte) [cite: 223, 273]
    public void PlaySFX(AudioClip clip, float volume)
    {
        EffectsSource.PlayOneShot(clip, volume);
    }

    // Para la música de fondo [cite: 311]
    public void PlayMusic(AudioClip clip, float volume = 0.5f)
    {
        MusicSource.clip = clip;
        MusicSource.loop = true;
        MusicSource.volume = volume;
        MusicSource.Play();
    }

    // Para el ambiente (bosque, viento) [cite: 25, 261]
    public void PlayAmbiance(AudioClip clip, float volume = 0.3f)
    {
        AmbianceSource.clip = clip;
        AmbianceSource.loop = true;
        AmbianceSource.volume = volume;
        AmbianceSource.Play();
    }

    public void PauseMusic(bool gamePaused)
    {
        if (gamePaused)
        {
            MusicSource.pitch = 0.95f;
            MusicSource.volume = 0.7f;
        }
        if (!gamePaused)
        {
            MusicSource.pitch = 1f;
            MusicSource.volume = 1f;
        }
    }
}