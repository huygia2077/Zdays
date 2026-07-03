using UnityEngine;
using System.Collections.Generic;

public class zombie_attack : MonoBehaviour
{
    [SerializeField] private float attackCoolDown = 1f, nextAttackTime = 0f;
    [SerializeField] private zombie_animation zombieAnimation;
    public List<GameObject> attackableObjects;


    public void performAttack()
    {   
        if (Time.time >= nextAttackTime)
        {
            Debug.Log("attack");
            nextAttackTime = Time.time + attackCoolDown;
            zombieAnimation.triggerAttack();
        }
    }

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
