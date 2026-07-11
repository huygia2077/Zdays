using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public BoxCollider2D cd;
    [SerializeField] public float lifeTime = 1f;


    void Start()
    {
        Destroy(gameObject, lifeTime); // Destory the bullet itself after a period of time
    }

    void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.CompareTag("enemy"))
        {
            healthInterface health = collision.gameObject.GetComponentInParent<healthInterface>();
            health.takeDamage(1f);
            Destroy(gameObject);
        }
    }
}
