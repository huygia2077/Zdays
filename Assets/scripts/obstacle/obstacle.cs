using UnityEngine;
using UnityEngine.EventSystems;

public class obstacle : MonoBehaviour
{
    [SerializeField] public ParticleSystem ashesEffect;
    [SerializeField] public BoxCollider2D boxCollider;

    [SerializeField] private Vector2 ashesSize;
    [SerializeField] private short particleCounts;

    [SerializeField] private ParticleSystem bulletFragments;
    [SerializeField] private Color bulletFragmentColor;
    private void playEffect()
    {   
        if (ashesEffect != null)
        {
            // Get modules such as main, shape, emission from the particle prefab
            var main = ashesEffect.main; 
            var shape  = ashesEffect.shape;
            var emission = ashesEffect.emission;

            // Get the area (size of obstacle)
            float area = boxCollider.size.x * boxCollider.size.y;

            // Modify particle's start size
            main.startSize = new ParticleSystem.MinMaxCurve(ashesSize.x, ashesSize.y);

            // Modify particle's shape
            shape.radius = Mathf.Max(boxCollider.size.x, boxCollider.size.y) * 0.12f;

            // Modify particle's number of particles
            emission.SetBursts(new ParticleSystem.Burst[]
            {
                new ParticleSystem.Burst(0f, particleCounts, particleCounts)
            });

            Instantiate(ashesEffect, transform.position, Quaternion.identity);
        }
    }


    void Start()
    {
        if (this.CompareTag("map_obstacle") == false)
        {
            playEffect();
        }
    }
    
    public void removeObject()
    {
        // Rescan the map before destroy an obstacle
        playEffect();
        Bounds bound = boxCollider.bounds;
        boxCollider.enabled = false;
        AstarPath.active.UpdateGraphs(bound);
        Destroy(gameObject);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            if (bulletFragments != null)
            {
                ParticleSystem fragment = Instantiate(bulletFragments, other.gameObject.GetComponent<Transform>().position, Quaternion.identity);
                var main = fragment.main;
                main.startColor = new ParticleSystem.MinMaxGradient(bulletFragmentColor);
            }
            Destroy(other.gameObject);
        }
    }

}
