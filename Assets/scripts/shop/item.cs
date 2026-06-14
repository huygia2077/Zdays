using UnityEngine;
using UnityEngine.UI;

public class item : MonoBehaviour
{
    [SerializeField] public itemInformation itemInfo;
    [SerializeField] public GameObject itemDisplay;

    void Start()
    {
        itemDisplay.transform.Find("icon").GetComponent<SpriteRenderer>().sprite = itemInfo.sprite;
        itemDisplay.transform.Find("name").GetComponent<Text>().text = itemInfo.name;
        itemDisplay.transform.Find("cost").GetComponent<Text>().text = itemInfo.cost.ToString();
        itemDisplay.transform.localScale *= itemInfo.scale;
        
    }
}
