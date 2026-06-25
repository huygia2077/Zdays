using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Audio;

public class transition : MonoBehaviour
{
    [SerializeField] public Animator animate;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private CanvasGroup transitionCanva;

    [SerializeField] private AudioMixer cutsceneMixer;
    [SerializeField] private float fadeDuration = 1.0f;


    public void loadScene()
    {
        StartCoroutine(loading(transitionTime));
    }

    IEnumerator loading(float transitionTime)
    {
        animate.SetTrigger("transit");
        transitionCanva.blocksRaycasts = true;
        transitionCanva.interactable = true;
        yield return new WaitForSeconds(transitionTime);
        if (cutsceneMixer)
        {
            StartCoroutine(FadeMixer());
        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    private IEnumerator FadeMixer()
    {
        float currentTime = 0;
        cutsceneMixer.GetFloat("cutsceneMixer", out float startVolume);
        float targetVolume = -80f; 

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            
            float newVol = Mathf.Lerp(startVolume, targetVolume, currentTime / fadeDuration);
                    
            cutsceneMixer.SetFloat("cutsceneMixer", newVol);
            
            yield return null;
        }
        cutsceneMixer.SetFloat("cutsceneMixer", -80f);
    }
}
