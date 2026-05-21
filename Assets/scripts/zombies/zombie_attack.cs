using UnityEngine;

public class zombie_attack : MonoBehaviour
{
    [SerializeField] public CircleCollider2D attack_range;

    void Start()
    {
        attack_range = transform.Find("attack_range").GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("obstacle") || other.CompareTag("solid_obstacle"))
        {
            Debug.Log(other.name); 
        }
    }
}
