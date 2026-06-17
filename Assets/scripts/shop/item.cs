using UnityEngine;
using UnityEngine.UI;

public class item : MonoBehaviour
{
    [SerializeField] public item_information itemInfo;
    [SerializeField] public shop_manager shopManager;
    [SerializeField] public prototype_manager prototypeManager;

    void Start()
    {
        // First get the icon object of the item, then its sprite
        GameObject icon = gameObject.transform.Find("icon").gameObject;
        Image iconImage = icon.GetComponent<Image>();
        iconImage.sprite = itemInfo.sprite;
        iconImage.SetNativeSize();
        icon.transform.localScale *= itemInfo.scale;

        // Setting up other values of the item to displat on shop UI
        gameObject.transform.Find("name").GetComponent<Text>().text = itemInfo.itemName;
        gameObject.transform.Find("cost").GetComponent<Text>().text = itemInfo.cost.ToString();
        gameObject.name = itemInfo.name;

        // Add event listener to button click when buying an item
        gameObject.GetComponent<Button>().onClick.AddListener(onBuy);

        // Get shop mananger to work with animtion after buying an item
        shopManager = GameObject.Find("shop").GetComponent<shop_manager>();

        // Get prototype manager
        prototypeManager = GameObject.Find("prototypeManager").GetComponent<prototype_manager>();
    }

    public void onBuy()
    {
        if (itemInfo.type == "object")
        {
            shopManager.closeShop();
            prototypeManager.enablePrototype(itemInfo);
        }
    }
}
