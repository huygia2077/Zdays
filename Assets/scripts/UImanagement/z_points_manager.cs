using UnityEngine;
using UnityEngine.UI;

public class z_points_manager : MonoBehaviour
{
    [SerializeField] public Text zPointText;
    public float zPoints = 0;

    public void addPoints(int amount)
    {
        zPoints += amount;
    }

    public bool removePoints(int amount)
    {
        if ((zPoints - amount) < 0)
        {
            return false;
        }
        zPoints -= amount;
        return true;
    }

    void Update()
    {
        zPointText.text = zPoints.ToString();
    }
}
