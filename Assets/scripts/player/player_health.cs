using UnityEngine;

public class player_health : MonoBehaviour, healthInterface
{
    public float maxHealth;
    public float currentHealth;

    void Start()
    {
        if (game_manager.instance.savedManager.hasLoadedDatas() == false)
        {
            currentHealth = maxHealth;
        }
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            game_manager.instance.triggerGameover();
        }
    }
}
