using UnityEngine;

public class shop_manager : MonoBehaviour
{
    public bool shopEnabled = false;
    private controlManager controlManager;
    void Start()
    {
        controlManager = GameObject.Find("Player").GetComponent<controlManager>();
    }
    public void openShop()
    {
        shopEnabled = true;
        controlManager.controlable = false;
    }
    public void closeShop()
    {
        shopEnabled = false;
        controlManager.controlable = true;
    }
}
