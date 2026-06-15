using UnityEngine;
using UnityEngine.UI;

public class item : MonoBehaviour
{
    [SerializeField] public itemInformation itemInfo;

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
    }

    public void onBuy()
    {
        Debug.Log("Buying " + itemInfo.itemName);
    }
}
