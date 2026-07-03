using UnityEngine;
using Pathfinding;
public class zombie_animation : MonoBehaviour
{
    [SerializeField] public Animator animator;
    // [SerializeField] public zombie_movement movement;
    private AIPath aiPath;

    void Start()
    {
        aiPath = gameObject.GetComponent<AIPath>();
    }

    public void triggerAttack()
    {
        animator.SetTrigger("attack");
    }
}
