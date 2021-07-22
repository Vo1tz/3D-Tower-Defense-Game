using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;

    public static bool begun;

    public AudioSource SFX;
    public AudioSource Music;
    public AudioMixer sfxmixer;
    public AudioMixer musicmixer;

    public static float sfxKnown;
    public static float musicKnown;

    public int musicindex = 0;

    public float LowPitchRange = 0.95f;
    public float HighPitchRange = 1.05f;

    public AudioClip[] BackgroundMusic;

    void Awake() {

        PlayMusic();

        musicmixer.SetFloat("musicVolP", musicKnown);
        sfxmixer.SetFloat("sfxVolP", sfxKnown);

        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if (Music.isPlaying == false)
        {
            musicindex++;
            PlayMusic();
        }
    }

    public void PlayAudio(AudioClip clip)
    {
        SFX.clip = clip;
        SFX.Play();
    }

    public void PlayMusic()
    { 
        Music.clip = BackgroundMusic[musicindex];
        Music.Play();
    }

    public void PlayRandomAudio(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

        SFX.pitch = randomPitch;
        SFX.clip = clips[randomIndex];
        SFX.Play();
    }

    // VOLUME MODIFICATION

    public void SetMusicVolume(float musicvol)
    {
        musicmixer.SetFloat("musicVolP", musicvol);
        musicKnown = (musicvol);
    }

    public void SetSFXVolume(float sfxvol)
    {
        sfxmixer.SetFloat("sfxVolP", sfxvol);
        sfxKnown = (sfxvol);
    }
}
