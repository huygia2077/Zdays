using UnityEngine;
using UnityEngine.InputSystem;
// using Pathfinding;
using UnityEngine.UI;
using System.Collections;

public class zombie_spawn_manager : MonoBehaviour
{
    [SerializeField] public GameObject zombies;
    [SerializeField] public BoxCollider2D spawnArea;
    // Timer for each zombie waves
    [SerializeField] private GameObject timer;
    [SerializeField] private int seconds = 60;
    private PlayerInput playerInput;
    private int zombieSpawnedCount;

    void Start()
    {
        playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
        playerInput.actions["StartNewWave"].performed += startWave;

        StartCoroutine(updatingTimer());
    }

    public void startSpawningTimer()
    {
        StartCoroutine(updatingTimer());
    }
    IEnumerator updatingTimer()
    {
        timer.SetActive(true);
        Text timerDisplay = timer.GetComponent<Text>();
        while (seconds > 0)
        {
            int minute = seconds/60;
            int second = seconds%60;
            if (seconds < 10)
            {
                timerDisplay.text = minute.ToString() + ":0" + second.ToString();
            }
            else
            {
                timerDisplay.text = minute.ToString() + ":" + second.ToString();
            }
            yield return new WaitForSeconds(1f);
            seconds--;
        }
        timer.SetActive(false);
        startSpawning();
    }

    public void startWave(InputAction.CallbackContext context)
    {
        startSpawning();
    }

    private void startSpawning()
    {
        AstarPath.active.Scan();
        zombieSpawnedCount = Random.Range(5, 10);
        spawnZombies(zombieSpawnedCount);
    }

    public void spawnZombies(int spawnAmount)
    {
        Bounds bound = spawnArea.bounds;
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(bound.min.x, bound.max.x), Random.Range(bound.min.y, bound.max.y), 0f);
            Instantiate(zombies, spawnPos, Quaternion.identity);
        }
    }
}
