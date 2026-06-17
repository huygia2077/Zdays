using UnityEngine;

public class zombie_health : MonoBehaviour
{
    [SerializeField] public float HP;
    [SerializeField] public int zPoints;
    [SerializeField] public zombie_dead_effet effect;
    [SerializeField] public GameObject damaged_blood;
    [SerializeField] public z_points_manager pointsManager;


    void Start()
    {
        pointsManager = GameObject.Find("killCount").GetComponent<z_points_manager>();
    }
    public void getDamage()
    {
        HP -= 1;
        for (int i=0 ; i<Random.Range(1f, 3f); i++)
        {
            Instantiate(damaged_blood, (Vector2)transform.position + Random.insideUnitCircle * Random.Range(0.05f, 0.2f), Quaternion.identity);
        }
    }

    void Update()
    {
        if (HP <= 0)
        {
            effect.play_dead_effect();
            pointsManager.addPoints(zPoints);
            Destroy(gameObject);
        }
    }
}
