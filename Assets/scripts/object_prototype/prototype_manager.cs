using UnityEngine;

public class prototype_manager : MonoBehaviour
{
    [SerializeField] public GameObject prototypePrefab;
    public void enablePrototype() 
    {   
        GameObject prototype = Instantiate(prototypePrefab, transform.position, Quaternion.identity);
        prototype.name = "prototypeObject";
    }

    public void disablePrototype()
    {
        GameObject prototype = GameObject.Find("prototypeObject");
        if (prototype)
        {
            prototype.GetComponent<prototypeObjects>().onDisabled();        
        }
    }
}
