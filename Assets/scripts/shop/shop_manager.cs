using UnityEngine;

public class shop_manager : MonoBehaviour
{
    [SerializeField] public Animator shopAnimation;


    public void openShop()
    {
        game_manager.instance.playerControlManager.controlable = false;
        shopAnimation.SetTrigger("openShop");
        game_manager.instance.prototypeManager.disablePrototype();
    }
    public void closeShop()
    {
        game_manager.instance.playerControlManager.controlable = true;
        shopAnimation.SetTrigger("closeShop");
    }
}
