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
        // // Detect collision with solid obstacle
        // if (collision.gameObject.CompareTag("solid_obstacle"))
        // {
        //     Instantiate(bulletFragments, gameObject.GetComponent<Transform>().position, Quaternion.identity);
        //     Destroy(gameObject);
        // }
        // Detect collision with zombies
        if (collision.gameObject.CompareTag("enemy"))
        {
            collision.gameObject.GetComponent<zombie_health>().getDamage();
        }
        // Destroy(gameObject);
    }
}
