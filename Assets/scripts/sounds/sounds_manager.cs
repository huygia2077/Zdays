using UnityEngine;
using System;
using UnityEngine.Audio;

public enum soundType
{
    GUNFIRE,
    RELOAD,
    HURT,
}

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class sounds_manager : MonoBehaviour
{
    public static sounds_manager intance;
    private AudioSource audioSource;
    [SerializeField] private audioGroups[] audios;
    
    [Serializable] public struct audioGroups {
        public AudioClip[] getSounds {get => sounds;}
        [HideInInspector] public string name;
        [SerializeField] AudioClip[] sounds;
    }
    
    void Awake()
    {
        intance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    #if UNITY_EDITOR
    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(soundType));
        Array.Resize(ref audios, names.Length);
        for (int i=0; i<names.Length; i++)
        {
            audios[i].name = names[i];
        }
    }
    #endif

    public void playSFX(soundType SFX, float vol = 1)
    {
        AudioClip[] audioClips = intance.audios[(int)SFX].getSounds;
        AudioClip audio = audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
        intance.audioSource.PlayOneShot(audio, vol);
    }
}
