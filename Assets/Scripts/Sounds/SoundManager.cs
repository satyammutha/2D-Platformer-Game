using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    public AudioSource soundEffect, soundBgMusic, soundDeath;
    public SoundType[] Sounds;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayBgMusic(SoundsForEvents.BgMusic);
    }

    public void PlayDeathMusic(SoundsForEvents sound)
    {
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundDeath.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("Clip not found for sound type:" + sound);
        }
    }

    public void PlayBgMusic(SoundsForEvents sound)
    {
        AudioClip clip = GetSoundClip(sound);
        if(clip != null)
        {
            soundBgMusic.clip = clip;
            soundBgMusic.Play();
        }
        else
        {
            Debug.Log("Clip not found for sound type:" + sound);
        }
    }

    public void Play(SoundsForEvents sound)
    {
        AudioClip clip = GetSoundClip(sound);
        if(clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("Clip not found for sound type:" + sound);
        }
    }

    private AudioClip GetSoundClip(SoundsForEvents sound)
    {
        SoundType item = Array.Find(Sounds, i => i.soundType == sound);
        if (item != null)
            return item.soundClip;
        return null;
    }
}

[Serializable]
public class SoundType
{
    public SoundsForEvents soundType;
    public AudioClip soundClip;
}

public enum SoundsForEvents
{
    ButtonClick,
    BgMusic,
    PlayerMove,
    PlayerDeath,
    EnemyDeath
}