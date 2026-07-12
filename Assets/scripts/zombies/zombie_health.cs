using UnityEngine;

public class zombie_health : MonoBehaviour, healthInterface
{
    [SerializeField] public float HP;
    [SerializeField] public int zPoints;
    [SerializeField] public zombie_dead_effet effect;
    [SerializeField] public GameObject damaged_blood;


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
            game_manager.instance.zombieSpawnerManager.killCount();
            game_manager.instance.addKillCount(1);
            Destroy(gameObject);
        }
    }
}
