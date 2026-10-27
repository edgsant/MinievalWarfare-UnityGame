using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerTutorial : MonoBehaviour
{
	public AudioSource EffectsSource;
	public AudioSource MusicSource;
	public AudioClip Ambiance;
	// Singleton instance.
	public static AudioManagerTutorial Instance = null;

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


	void Start()
	{
		PlayMusic(Ambiance);
	}


	// Play a single clip through the sound effects source.
	public void PlayClip(AudioClip clip)
	{
		EffectsSource.PlayOneShot(clip);
	}

	// Play a single clip through the music source.
	public void PlayMusic(AudioClip clip)
	{
		MusicSource.clip = clip;
		MusicSource.Play();
		MusicSource.loop = true;
	}


}
