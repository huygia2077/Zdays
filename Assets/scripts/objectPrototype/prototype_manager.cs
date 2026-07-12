using UnityEngine;

public class prototype_manager : MonoBehaviour
{
    [SerializeField] public GameObject prototypePrefab;  // The prototype object shows where player can place their obstacle


    // Function shows the demonstration of prototype where player can place their obstacle
    public void enablePrototype(item_information itemInfo) 
    {   
        // Modify prototype 
        GameObject prototype = Instantiate(prototypePrefab, transform.position, Quaternion.identity);
        prototype.name = "prototypeObject";
        prototype.GetComponent<SpriteRenderer>().sprite = itemInfo.sprite;
        prototype.GetComponent<prototype_objects>().placedObject = itemInfo.objectPrefab;
        prototype.transform.localScale = new Vector3(itemInfo.objectScalingSize, itemInfo.objectScalingSize, itemInfo.objectScalingSize);
        prototype.GetComponent<prototype_objects>().cost = itemInfo.cost;
    }
    // Function hides the demonstration of prototype when finish placing
    public void disablePrototype()
    {
        GameObject prototype = GameObject.Find("prototypeObject");
        if (prototype)
        {
            // Cancel the action in prototype input
            prototype.GetComponent<prototype_objects>().onDisabled();        
        }
    }
}
