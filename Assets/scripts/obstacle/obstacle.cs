using UnityEngine;
using UnityEngine.EventSystems;

public class obstacle : MonoBehaviour
{
    [SerializeField] public ParticleSystem ashesEffect;
    [SerializeField] public BoxCollider2D boxCollider;

    [SerializeField] private Vector2 ashesSize;
    [SerializeField] private short particleCounts;

    private void playEffect()
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


    void Start()
    {
        playEffect();
    }
    
    public void removeObject()
    {
        // Rescan the map before destroy an obstacle
        Bounds bound = boxCollider.bounds;
        boxCollider.enabled = false;
        AstarPath.active.UpdateGraphs(bound);
        playEffect();
        Destroy(gameObject);
    }

}
