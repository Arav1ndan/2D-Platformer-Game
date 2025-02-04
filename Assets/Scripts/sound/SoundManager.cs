using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
 
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    

    public AudioSource SoundEffect;
    public AudioSource SoundMusic;

    public SoundType[] Sounds;
    public bool isMute = false;
    public float Volume = 1f;

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
        SetVolume(0.5f);
        PlayMusic(global::Sounds.Music);
    }
    public void Mute(bool status)
    {
        isMute = status;
    }
    public void SetVolume(float volume)
    {
        Volume = volume;
        SoundEffect.volume = Volume;   
        SoundMusic.volume = Volume; 
    }
    public void PlayMusic(Sounds sounds)
    {
        if (isMute)
            return;
        AudioClip clip = getSoundClip(sounds);
        if (clip != null)
        {
            SoundMusic.clip = clip;
            SoundMusic.Play();
        }
        else
        {
            Debug.LogError(" clip not found.." + sounds);
        }
    }
    public void Play(Sounds sound)
    {
        if (isMute)
            return;
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            SoundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError(" clip not found.."+ sound);
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(Sounds, i => i.SoundTypes == sound);
        if(item != null)
        {
            return item.soundClips;
        }
        return null;
    }
}
[Serializable]
public class SoundType
{
    public Sounds SoundTypes;
    public AudioClip soundClips;
}
public enum Sounds
{
    ButtonClick,
    Music,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
    LevelStart,
    LevelComplete,
    LevelFail
}
