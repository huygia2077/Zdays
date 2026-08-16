using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Audio;

public enum soundType
{
    GUNFIRE,
    METAL_IMPACT,
    SAND_IMPACT,
    EMPTY_SHOT,
    RELOAD,
    HURT,
    TICK,
}

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class sounds_manager : MonoBehaviour
{
    public static sounds_manager intance;
    [SerializeField] private AudioMixer masterMixer;
    [SerializeField] private float fadeDuration = 2f;

    private AudioSource audioSource;
    [SerializeField] private audioGroups[] audios;
    
    [Serializable] public struct audioGroups {
        public AudioClip[] getSounds {get => sounds;}
        [HideInInspector] public string name;
        [SerializeField] AudioClip[] sounds;
    }
    
    // Initialize Audios
    void Awake()
    {
        intance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        masterMixer.SetFloat("masterMixer", 0f);
    }


    // Change the audio groups name
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


    // Trigger SFX
    public void playSFX(soundType SFX, float vol = 1)
    {
        AudioClip[] audioClips = intance.audios[(int)SFX].getSounds;
        AudioClip audio = audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
        intance.audioSource.PlayOneShot(audio, vol);
    }


    // Fade Audios
    public void FadeMasterVolumn()
    {
        StartCoroutine(FadeMixer());
    }
    private IEnumerator FadeMixer()
    {   
        float startVolume;
        float currentTime = 0;
        masterMixer.GetFloat("masterMixer", out  startVolume);
        float targetVolume = -80f; 

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            
            float newVol = Mathf.Lerp(startVolume, targetVolume, currentTime / fadeDuration);
                    
            masterMixer.SetFloat("masterMixer", newVol);
            
            yield return null;
        }
        masterMixer.SetFloat("masterMixer", -80f);
    }
}
