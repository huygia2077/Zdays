using UnityEngine;

public class player_health : MonoBehaviour, healthInterface
{
    public float maxHealth;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
