using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class transition : MonoBehaviour
{
    [SerializeField] public Animator animate;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private CanvasGroup transitionCanva;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
