using UnityEngine;
using UnityEngine.EventSystems;

public class remove_obstacle : MonoBehaviour
{
    [SerializeField] public ParticleSystem ashesEffect;
    [SerializeField] public BoxCollider2D boxCollider;

    private void playEffect()
    {   
        // Get modules such as main, shape, emission from the particle prefab
        var main = ashesEffect.main; 
        var shape  = ashesEffect.shape;
        var emission = ashesEffect.emission;

        // Get the area (size of obstacle)
        float area = boxCollider.size.x * boxCollider.size.y;

        // Modify particle's start size
        main.startSize = new ParticleSystem.MinMaxCurve(0.1f * area * 0.5f, 0.3f * area * 0.5f);

        // Modify particle's shape
        shape.radius = Mathf.Max(boxCollider.size.x, boxCollider.size.y) * 0.1f;

        // Modify particle's number of particles
        short particleCounts = (short)Mathf.RoundToInt(area * 2f);
        emission.SetBursts(new ParticleSystem.Burst[]
        {
            new ParticleSystem.Burst(0f, particleCounts, particleCounts)
        });

        Instantiate(ashesEffect, transform.position, Quaternion.identity);
    }

    public void removeObject()
    {
        playEffect();
        Destroy(gameObject);
    }
}
