using UnityEngine;

public class obstacle_health : MonoBehaviour, healthInterface
{
    [SerializeField] public float currentHealth;
    [SerializeField] private obstacle obstacle;
    [SerializeField] private build_identifier buildIdentifier;

    void Start()
    {
        buildIdentifier.currentDamagedStat = currentHealth;
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        buildIdentifier.currentDamagedStat = currentHealth;
        if (currentHealth <= 0)
        {            
            buildIdentifier.currentDamagedStat = 0;
            game_manager.instance.removeInActiveBuild(this.gameObject);
            obstacle.removeObject();
        }
    }
}
