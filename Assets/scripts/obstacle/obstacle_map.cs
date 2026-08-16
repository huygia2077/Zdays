using UnityEngine;
using UnityEngine.EventSystems;

public class obstacle_map : MonoBehaviour
{
    [SerializeField] public BoxCollider2D boxCollider;
    [SerializeField] private ParticleSystem bulletFragments;
    [SerializeField] private Color bulletFragmentColor;
    [SerializeField] private soundType impactSound;
    [SerializeField] private float impactVolumn;



    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            if (bulletFragments != null)
            {
                ParticleSystem fragment = Instantiate(bulletFragments, other.gameObject.GetComponent<Transform>().position, Quaternion.identity);
                var main = fragment.main;
                main.startColor = new ParticleSystem.MinMaxGradient(bulletFragmentColor);
                game_manager.instance.soundsManager.playSFX(impactSound, impactVolumn);
            }
            Destroy(other.gameObject);
        }
    }

}
