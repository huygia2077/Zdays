using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public BoxCollider2D cd;
    [SerializeField] public float lifeTime = 1f;
    [SerializeField] public GameObject bulletFragments;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("solid_obstacle"))
        {
            Instantiate(bulletFragments, gameObject.GetComponent<Transform>().position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            collision.gameObject.GetComponent<zombie_health>().getDamage();
            Destroy(gameObject);
        }
    }
}
