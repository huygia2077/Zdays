using UnityEngine;
using UnityEngine.InputSystem;
using Pathfinding;

public class zombie_spawn_manager : MonoBehaviour
{
    [SerializeField] public GameObject zombies;
    [SerializeField] public BoxCollider2D spawnArea;
    private PlayerInput playerInput;

    void Start()
    {
        playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
        playerInput.actions["StartNewWave"].performed += spawnZombie;
    }

    public void spawnZombie(InputAction.CallbackContext context)
    {
        AstarPath.active.Scan();
        Bounds bound = spawnArea.bounds;
        Vector3 spawnPos = new Vector3(Random.Range(bound.min.x, bound.max.x), Random.Range(bound.min.y, bound.max.y), 0f);
        Instantiate(zombies, spawnPos, Quaternion.identity);
    }
}
