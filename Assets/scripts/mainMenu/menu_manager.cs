using UnityEngine;
using System.Collections;

public class menu_manager : MonoBehaviour
{
    [SerializeField] private GameObject lightpole;


    IEnumerator lightFlickering()
    {
        while (true)
        {
            for (int i=0; i < Random.Range(1, 7); i++)
            {
                lightpole.SetActive(false);
                yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
                lightpole.SetActive(true); 
                yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
            }

            yield return new WaitForSeconds(Random.Range(2, 4));
        }
    }


    public void quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }


    void Start()
    {
        StartCoroutine(lightFlickering());
    }
}
