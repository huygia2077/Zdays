using UnityEngine;

public class blood : MonoBehaviour
{   
    void Start()
    {
        transform.localScale *= Random.Range(1f, 1.5f);
    }
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Random.Range(0.05f, 0.5f) * Time.deltaTime);
        if (transform.localScale.sqrMagnitude <= 0.0001f)
        {
            Destroy(gameObject);
        }
    }
}
