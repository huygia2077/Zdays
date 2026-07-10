using UnityEngine;
using System.Collections.Generic;

public class zombie_attack : MonoBehaviour
{
    // Attack cooldown
    [SerializeField] private float attackCoolDown = 1f, nextAttackTime = 0f;
    
    // Zombie Animation
    [SerializeField] private zombie_animation zombieAnimation;

    // Objects in attack range
    public List<GameObject> attackableObjects;


    // Execure zombie attack
    public void performAttack()
    {   
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + attackCoolDown;
            zombieAnimation.triggerAttack();
        }
    }

    
    // Deal damage
    public void dealAttackDamage()
    {
        foreach (GameObject obj in attackableObjects)
        {
            healthInterface health = obj.GetComponentInParent<healthInterface>();
            if (health != null)
            {
                health.takeDamage(10f);
            }
        }
    }

    
}
