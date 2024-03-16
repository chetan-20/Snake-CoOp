using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private static SoundController instance;
    public static SoundController Instance { get { return instance; } }
    public AudioSource SoundEffect;
    public AudioSource SoundMusic;
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
        PlayMusic(global::Sounds.BGmusic);
    }
    private AudioClip GetSoundClip(Sounds sound)
    {

        SoundType item = Array.Find(Sounds, i => i.soundtype == sound);
        if (item != null)
        {
            return item.soundclip;
        }
        else
        {
            return null;
        }
    }
    public void PlayMusic(Sounds sound)
    {
        
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            SoundMusic.clip = clip;
            SoundMusic.Play();
        }
        else
        {
            Debug.Log("Audio Not Assigned 1");
        }
    }
    public void PlaySound(Sounds sound)
    {
        
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            SoundEffect.PlayOneShot(clip);

        }
        else
        {
            Debug.Log("Audio Not Assigned 2");
        }
    }
}

[Serializable] public class SoundType
{
    public Sounds soundtype;
    public AudioClip soundclip;
}
public enum Sounds
    {
        BGmusic,
        AppleEatingSound,
        BadAppleEatingSound,
        GameOverSound,
        ButtonClickSound,
        PowerUpSound
    }