using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Audio;

public class transition : MonoBehaviour
{
    [Header("Transition Screen")]
    [SerializeField] public Animator animate;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private CanvasGroup transitionCanva;

    // [Header("Audio Control")]

    // [SerializeField] private AudioMixer mixer;
    // [SerializeField] private string mixerStringVal;
    // [SerializeField] private float fadeDuration = 1.0f;


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

        sounds_manager.intance.FadeMasterVolumn();

        yield return new WaitForSeconds(2f);
        if (sceneIndex == -1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }




    
}
