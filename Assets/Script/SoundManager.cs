using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0f, 3f)]
    public float pitch;

    //public bool loop;

    [HideInInspector]
    public AudioSource source;
}

public class SoundManager : MonoBehaviour
{
    public Sound[] soundManager;
    public AudioMixer controlSound;
    private AudioSource[] allAudioSources;

    void Awake()
    {
        foreach(Sound s in soundManager)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.volume = s.pitch;
        }
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(soundManager, sound => sound.name == name);
        s.source.Play();
    }
}
