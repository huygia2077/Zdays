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

    // Load Scene
    public void loadScene()
    {
        StartCoroutine(loading(transitionTime));
    }

    // Restart gameplay
    public void restartGameplay()
    {
        StartCoroutine(loading(transitionTime, 2));
    }

    // Load Menu
    public void loadMenu()
    {
        StartCoroutine(loading(transitionTime, 0));
    }


    // Trigger scene transition
    IEnumerator loading(float transitionTime, int sceneIndex = -1)
    {
        // Starting transition
        animate.SetTrigger("transit");
        transitionCanva.blocksRaycasts = true;
        transitionCanva.interactable = true;
        yield return new WaitForSeconds(transitionTime);

        // Fade the audios
        sounds_manager.intance.FadeMasterVolumn();
        yield return new WaitForSeconds(2f);

        // Load next scene
        if (sceneIndex == -1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }    
}
