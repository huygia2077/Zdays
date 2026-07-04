using UnityEngine;
using UnityEngine.InputSystem;
using Pathfinding;
using UnityEngine.UI;
using System.Collections;

public class zombie_spawn_manager : MonoBehaviour
{
    private PlayerInput playerInput;

    // Zombie Spawn
    [SerializeField] public GameObject zombies;
    [SerializeField] public BoxCollider2D spawnArea;

    // Timer for each zombie waves
    [SerializeField] private GameObject timer;
    [SerializeField] private int seconds = 60;
    private WaitForSeconds oneSecondWait = new WaitForSeconds(1f);
    private Coroutine timerCoroutine = null;
    public int zombieSpawnedCount;


    // Start -> startTimer() -> stopTimer() -> startSpawn()
    //                       -> startWave() -> stopTimer -> startSpawn()

    void Start()
    {
        AstarPath.active.Scan();
        playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
        playerInput.actions["StartNewWave"].performed += startWave;

        startTimer();
    }

    // Start the spawn timer
    private void startTimer()
    {
        if (timerCoroutine == null)
        {
            timerCoroutine = StartCoroutine(updatingTimer());
        }
    }


    // Stop/kill spawn timer by player's input or times out
    private void stopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }


    // Updating timer
    IEnumerator updatingTimer()
    {
        timer.SetActive(true);
        Text timerDisplay = timer.GetComponentInChildren<Text>();
        int secs = seconds;

        while (secs > 0)
        {
            int minute = secs/60;
            int second = secs%60;
            if (second < 10)
            {
                timerDisplay.text = minute.ToString() + ":0" + second.ToString();
            }
            else
            {
                timerDisplay.text = minute.ToString() + ":" + second.ToString();
            }
            yield return oneSecondWait;
            secs--;
        }

        stopTimer();
        timer.SetActive(false);
        startSpawn();
    }


    // Start zombie wave
    public void startWave(InputAction.CallbackContext context)
    {
        stopTimer();
        timer.SetActive(false);
        startSpawn();
    }


    // Start spawning zombie
    private void startSpawn()
    {
        zombieSpawnedCount = Random.Range(5, 10);
        StartCoroutine(spawnZombies(zombieSpawnedCount));
    }

    // Slowly spawn the zombie each second
    IEnumerator spawnZombies(int spawnAmount)
    {
        Bounds bound = spawnArea.bounds;
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(bound.min.x, bound.max.x), Random.Range(bound.min.y, bound.max.y), 0f);
            Instantiate(zombies, spawnPos, Quaternion.identity);
            yield return oneSecondWait;
        }
    }


    // Restart timer when wave is finished
    public void killCount()
    {
        zombieSpawnedCount -= 1;
        if (zombieSpawnedCount <= 0)
        {
            startTimer();
        }
    }
}
