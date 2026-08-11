using UnityEngine;
using UnityEngine.EventSystems;

public class obstacle_map : MonoBehaviour
{
    [SerializeField] public BoxCollider2D boxCollider;
    [SerializeField] private ParticleSystem bulletFragments;
    [SerializeField] private Color bulletFragmentColor;



    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            if (bulletFragments != null)
            {
                ParticleSystem fragment = Instantiate(bulletFragments, other.gameObject.GetComponent<Transform>().position, Quaternion.identity);
                var main = fragment.main;
                main.startColor = new ParticleSystem.MinMaxGradient(bulletFragmentColor);
                game_manager.instance.soundsManager.playSFX(soundType.SAND_IMPACT, 0.05f);
            }
            Destroy(other.gameObject);
        }
    }

}
