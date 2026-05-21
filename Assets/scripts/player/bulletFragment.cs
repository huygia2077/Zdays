using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class bulletFragment : MonoBehaviour
{
    [SerializeField] public Light2D sparkLight;

    void Start()
    {
        StartCoroutine(spark());
    }

    IEnumerator spark ()
    {
        sparkLight.enabled = true;
        yield return new WaitForSeconds(0.05f);
        sparkLight.enabled = false;
    }
}
