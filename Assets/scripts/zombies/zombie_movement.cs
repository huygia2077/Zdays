using UnityEngine;
using Pathfinding;

public class zombie_movement : MonoBehaviour
{
    [SerializeField] public GameObject mainTarget;
    [SerializeField] public float speed;
    private AIPath aiPath;
    private float stuckTime = 0f, stuckDuration = 1f;
    private Vector3 lastPosition;

    void Start()
    {
        aiPath = gameObject.GetComponent<AIPath>();
        aiPath.maxSpeed = speed;
        mainTarget = GameObject.FindGameObjectWithTag("mainTarget");
        lastPosition = gameObject.transform.position;
    }

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
        // Debug.Log(stuckTime);
        lastPosition = gameObject.transform.position;
        return stuckTime >= stuckDuration;
    }


    void Update()
    {
        aiPath.destination = mainTarget.transform.position;
    }

}
