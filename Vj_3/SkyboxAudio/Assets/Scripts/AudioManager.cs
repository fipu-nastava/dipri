using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    public AudioSound[] sounds;

    private AudioSound Find(SoundType s)
    {
        return Array.Find(sounds, sound => sound.type == s);
    }

    public void Play(SoundType s)
    {
        var playSound = Find(s);
        if (playSound != null)
        {
            playSound.source.Play();
        }
    }

    // Stop a specific sound
    public void Stop(SoundType s)
    {
        var playSound = Find(s);
        if (playSound != null)
        {
            playSound.source.Stop();
        }
    }

    // Pause a specific sound
    public void Pause(SoundType s)
    {
        var playSound = Find(s);
        if (playSound != null)
        {
            playSound.source.Pause();
        }
    }

    // This will create a seperate AudioSource component for each sound
    // This let us playing muliple sounds in parallel
    private void InitSources()
    {
        foreach(var sound in sounds)
        {
            // Create a AudioSource
            var source = gameObject.AddComponent<AudioSource>();
            // set an audio source
            source.clip = sound.audioClip;
            source.loop = sound.loop;
            source.volume = sound.volume;

            sound.source = source;

        }

    }


    #region Singleton
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            // If this is a duplicate of the same game object
            // destroy the duplicate
            Destroy(gameObject);
            return;
        }

        // Don't destroy this gameObject when changing the scenes
        // This will "copy" this gameObject to any new opened scene
        DontDestroyOnLoad(gameObject);

        InitSources();
    }
    #endregion

}
