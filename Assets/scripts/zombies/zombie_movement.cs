using UnityEngine;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;


public class zombie_movement : MonoBehaviour
{
    // Zombie's target objects
    [SerializeField] private GameObject defaultTarget;
    [SerializeField] private GameObject player;
    [SerializeField] private List<GameObject> objectsInRange = new List<GameObject>();

    // Zombie attack manager
    [SerializeField] private zombie_attack zombieAttack;

    // Zombie movement
    [SerializeField] public float speed;
    private AIPath aiPath;
    private float stuckTime = 0f, stuckDuration = 1f;
    private Vector3 lastPosition;
    private WaitForSeconds updatingPathFrequency = new WaitForSeconds(0.5f);

    void Start()
    {
        aiPath = gameObject.GetComponent<AIPath>();
        aiPath.maxSpeed = speed;
        defaultTarget = GameObject.Find("defaultTarget");
        player = GameObject.FindGameObjectWithTag("Player");
        lastPosition = gameObject.transform.position;
        zombieAttack.attackableObjects = objectsInRange;

        // Repeatedly updating zombie's path every second
        StartCoroutine(caculatingPath());

    }


    // Updating path
    IEnumerator caculatingPath()
    {
        while (true)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < 4f)
            {
                aiPath.destination = player.transform.position;
            }
            else
            {
                aiPath.destination = defaultTarget.transform.position;
            }
            aiPath.SearchPath();

            yield return updatingPathFrequency;
        }
    }


    // Check if zombie is stuck
    public bool isStuck()
    {   
        float distance = Vector3.Distance(lastPosition, gameObject.transform.position);

        if (distance > 0.001f)
        {
            stuckTime = 0;
        }
        else
        {
            stuckTime += Time.deltaTime;
        }


        lastPosition = gameObject.transform.position;
        return stuckTime >= stuckDuration;
    }
    

    // Find nearest object (find the player purpose)
    private GameObject findNearestObject()
    {
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        GameObject closest = null;

        foreach(GameObject obj in objectsInRange)
        {
            float dist = (obj.transform.position - currentPos).sqrMagnitude;
            if (dist < minDist)
            {
                closest = obj;
                minDist = dist;
            }
        }
        
        return closest;
    }


    // Check what object are in attacking zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("obstacle"))
        {
            objectsInRange.Add(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("obstacle"))
        {
            objectsInRange.Remove(other.gameObject);
        }
    }

    
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 0.5f || isStuck())
        {
            zombieAttack.performAttack();
        }
    }

}
