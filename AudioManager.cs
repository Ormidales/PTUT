using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("bg_gare");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if(s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if(s == null)
        {
            Debug.Log("Sound Not Found");
        }

        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
    
    public void StopMusic()
	{
	    musicSource.Stop();
	}
	
    public void StopSFX()
	{
	    sfxSource.Stop();
	}
    
    public void PlayMusicWithFadeOut(string name, float fadeOutDuration = 1f)
	{
	    Sound s = Array.Find(musicSounds, x => x.name == name);

	    if (s == null)
	    {
		Debug.Log("Sound Not Found");
	    }
	    else
	    {
		StartCoroutine(FadeOutMusic(fadeOutDuration));
		Invoke("PlayNewMusic", fadeOutDuration);
	    }
	}

	private IEnumerator FadeOutMusic(float fadeOutDuration)
	{
	    float startVolume = musicSource.volume;
	    while (musicSource.volume > 0)
	    {
		musicSource.volume -= startVolume * Time.deltaTime / fadeOutDuration;
		yield return null;
	    }
	    musicSource.Stop();
	    musicSource.volume = startVolume;
	}

	private void PlayNewMusic(string name)
	{
	    Sound s = Array.Find(musicSounds, x => x.name == name);

	    if (s == null)
	    {
		Debug.Log("Sound Not Found");
	    }
	    else
	    {
		musicSource.clip = s.clip;
		musicSource.Play();
	    }
	}

}
