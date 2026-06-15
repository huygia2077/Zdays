using UnityEngine;

public class shop_manager : MonoBehaviour
{
    public bool shopEnabled = false;
    [SerializeField] public Animator shopAnimation;
    private controlManager controlManager;
    private prototype_manager prototypeManager;
    void Start()
    {
        controlManager = GameObject.Find("Player").GetComponent<controlManager>();
        prototypeManager = GameObject.Find("prototypeManager").GetComponent<prototype_manager>();
    }
    public void openShop()
    {
        shopEnabled = true;
        controlManager.controlable = false;
        shopAnimation.SetTrigger("openShop");
        prototypeManager.disablePrototype();
    }
    public void closeShop()
    {
        shopEnabled = false;
        controlManager.controlable = true;
        shopAnimation.SetTrigger("closeShop");
    }
}
