﻿using UnityEngine;
using Unity.Audio;

public enum SoundType
{
    Punch,
    Hit,
    BackgroundTheme
}

[System.Serializable]
public class AudioSound 
{
    public SoundType type;

    public AudioClip audioClip;

    [Range(0f, 1f)]
    public float volume;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}