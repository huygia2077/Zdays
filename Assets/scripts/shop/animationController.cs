using UnityEngine;

public class animationController : MonoBehaviour
{
    [SerializeField] public Animator shopAnimation;

    public void openShop()
    {
        shopAnimation.SetTrigger("openShop");
    }

    public void closeShop()
    {
        shopAnimation.SetTrigger("closeShop");
    }
}
