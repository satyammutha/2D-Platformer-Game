using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    public AudioSource soundEffect, soundMusic;
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
        PlayMusic(SoundsForEvents.BgMusic);
    }

    public void PlayMusic(SoundsForEvents sound)
    {
        AudioClip clip = GetSoundClip(sound);
        if(clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.Log("Clip not found for sound type:" + sound);
        }
    }

    public void PlayOnce(SoundsForEvents sound)
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
    ButtonPlayClick,
    ButtonEnterLevelClick,
    BgMusic,
    PlayerStepJump,
    PlayerStepJumpLand,
    PlayerJump,
    PlayerDeath,
    KeyPickup,
    LevelComplete,
    BackButton,
    DisableClick,
    PlayerKilled
}