using UnityEngine;

public class player_health : MonoBehaviour, healthInterface
{
    public float maxHealth;
    public float currentHealth;
    [SerializeField] private game_manager gameManager;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            gameManager.triggerGameover();
        }
    }
}
