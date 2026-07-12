using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Audio;

public class transition : MonoBehaviour
{
    [SerializeField] public Animator animate;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private CanvasGroup transitionCanva;

    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string mixerStringVal;
    [SerializeField] private float fadeDuration = 1.0f;


    public void loadScene()
    {
        StartCoroutine(loading(transitionTime));
    }

    public void restartGameplay()
    {
        StartCoroutine(loading(transitionTime, 2));
    }

    public void loadMenu()
    {
        StartCoroutine(loading(transitionTime, 0));
    }

    IEnumerator loading(float transitionTime, int sceneIndex = -1)
    {
        animate.SetTrigger("transit");
        transitionCanva.blocksRaycasts = true;
        transitionCanva.interactable = true;
        yield return new WaitForSeconds(transitionTime);
        if (mixer)
        {
            StartCoroutine(FadeMixer());
        }
        yield return new WaitForSeconds(2f);
        if (sceneIndex == -1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }




    private IEnumerator FadeMixer()
    {
        float currentTime = 0;
        mixer.GetFloat(mixerStringVal, out float startVolume);
        float targetVolume = -80f; 

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            
            float newVol = Mathf.Lerp(startVolume, targetVolume, currentTime / fadeDuration);
                    
            mixer.SetFloat(mixerStringVal, newVol);
            
            yield return null;
        }
        mixer.SetFloat(mixerStringVal, -80f);
    }
}
