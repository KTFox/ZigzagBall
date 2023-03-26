using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class Sound
    {
        public string name;

        public AudioClip audioClip;

        [Range(0f, 1f)] public float volume;
        [Range(0.1f, 3f)] public float pitch;
        public bool loop;

        [HideInInspector] public AudioSource source;
    }



    //Variables
    public static AudioManager instance;
    public Sound[] sounds;

    //Event functions
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.audioClip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    //Methods
    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}