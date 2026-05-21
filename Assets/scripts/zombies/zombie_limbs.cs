using UnityEngine;

public class zombie_limbs : MonoBehaviour
{
    [SerializeField] public SpriteRenderer sprite;
    [SerializeField] public Vector2 lifetime;

    void Update()
    {
        Color color = sprite.color;
        color.a -= Time.deltaTime * Random.Range(lifetime.x, lifetime.y);
        sprite.color = color;

        if (sprite.color.a <= 0.01f)
        {
            Destroy(gameObject);
        }
    }

}
