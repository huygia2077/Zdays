using UnityEngine;

public class obstacke_health : MonoBehaviour, healthInterface
{
    [SerializeField] public float current_health;
    [SerializeField] private obstacle obstacle;
    public void takeDamage(float damage)
    {
        current_health -= damage;
        if (current_health <= 0)
        {            
            obstacle.removeObject();
        }
    }
}
