using UnityEngine;

public class zombie_health : MonoBehaviour, healthInterface
{
    [SerializeField] public float HP;
    [SerializeField] public int zPoints;
    [SerializeField] public zombie_dead_effet effect;
    [SerializeField] public GameObject damaged_blood;
    [SerializeField] public z_points_manager pointsManager;
    [SerializeField] public zombie_spawn_manager spawnerManager;


    void Start()
    {
        pointsManager = GameObject.Find("killCount").GetComponent<z_points_manager>();
        spawnerManager = GameObject.Find("zombieSpawnerManager").GetComponent<zombie_spawn_manager>();
    }
    public void takeDamage(float damage)
    {
        HP -= damage;
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
            spawnerManager.killCount();
            Destroy(gameObject);
        }
    }
}
