using UnityEngine;

[CreateAssetMenu(fileName = "itemInformation", menuName = "Scriptable Objects/itemInformation")]
public class itemInformation : ScriptableObject
{
    public Sprite sprite;
    public float scale;
    public float objectScalingSize;
    public int cost;
    public string type;
    public string itemName;
    public string discription;
    public GameObject objectPrefab;
}
