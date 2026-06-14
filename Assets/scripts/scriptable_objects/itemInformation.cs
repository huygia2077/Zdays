using UnityEngine;

[CreateAssetMenu(fileName = "itemInformation", menuName = "Scriptable Objects/itemInformation")]
public class itemInformation : ScriptableObject
{
    public Sprite sprite;
    public float scale;
    public int cost;
    public string itemName;
    public string discription;
}
