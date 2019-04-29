using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume;

        [Range(.1f, 3f)]
        public float pitch;
        public bool loop;
        public bool playOnAwake;

        [HideInInspector]
        public AudioSource source;
    }

    public Sound[] sounds;

    public static AudioManager Instance;

    public Sprite mutedSprite, unmutedSprite;

    public bool isMuted = false;

    private float muteVolume = 0f;

    void Awake()
    {
        Instance = this;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;

            s.source.playOnAwake = s.playOnAwake;
        }
    }

   
    public void toggleMuteAll(GameObject _volumeButton)
    {
        if (_volumeButton != null)
        {
            if (isMuted == true)
            {
                unMuteAllAudio();
                isMuted = false;
            }
            else if (isMuted == false)
            { 
                muteAllAudio();
                isMuted = true;
            }
        }
        else
        {
            Debug.Log("Button not found!");
        }

    }

    public void playSound(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);

        if (s != null)
        {
            s.source.Play();

            Debug.Log("Play: " + soundName);
        }
    }

    public void stopAllSounds()
    {
        foreach (Sound s in sounds)
        {
            if (s != null)
            {
                s.source.Stop();
            }
        }

    }


    public void stopSound(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);

        if (s != null)
        {
            s.source.Stop();
        }
    }

    public void muteAllAudio()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = muteVolume;
        }
    }

    public void unMuteAllAudio()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = s.volume;
        }
    }
}
