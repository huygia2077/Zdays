using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class prototype_objects : MonoBehaviour
{
    public GameObject placedObject;
    private float inputDirection;
    private int collisionCount = 0;
    [SerializeField] public Camera cam;
    [SerializeField] public SpriteRenderer sprite;
    [SerializeField] public Color placeableColor;
    [SerializeField] public Color unplaceableColor;
    [SerializeField] public float rotateSpeed;
    [SerializeField] private PlayerInput playerInput;


    void Start()
    {
        cam = Camera.main;
        sprite = gameObject.GetComponent<SpriteRenderer>();

        // Add onPlace() function to action "Place" of player
        playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
        playerInput.actions["Place"].performed += onPlace;

        // Add BoxCollider2D when enable prototype object
        BoxCollider2D bc =transform.AddComponent<BoxCollider2D>();
        bc.isTrigger = true;
    }


    // Dectecting whether the prototype is collided with anything in the current scene
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("obstacle") || other.CompareTag("Player") || other.CompareTag("map_obstacle"))
        {
            collisionCount++;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("obstacle") || other.CompareTag("Player") || other.CompareTag("map_obstacle"))
        {
            collisionCount--;
            collisionCount = Mathf.Max(0, collisionCount);
        }
    }


    // Function trigger the place action when player wants to place object
    void onPlace(InputAction.CallbackContext context)
    {
        if (!(collisionCount > 0))
        {
            // Place the obstacle then scan the map for pathfinding
            GameObject objects = Instantiate(placedObject, transform.position, transform.rotation);
            Bounds bound = objects.GetComponent<BoxCollider2D>().bounds;
            AstarPath.active.UpdateGraphs(bound);
        }
    }


    // Clear the action "place" when finishing placing
    public void onDisabled()
    {
        playerInput.actions["Place"].performed -= onPlace;
        Destroy(gameObject);
    }


    // Update the rotation of prototype
    void rotationUpdate()
    {
        inputDirection = playerInput.actions["RotatePrototype"].ReadValue<float>();
        if (inputDirection != 0)
        {
            float direction = Mathf.Sign(inputDirection);
            float rotationAmount = direction * rotateSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward * rotationAmount);
        }
    }


    void Update()
    {
        if (cam == null || Mouse.current == null) return;
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 targetWorldPos = cam.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, cam.nearClipPlane));
        targetWorldPos.z = transform.position.z;
        transform.position = targetWorldPos;

        if (collisionCount > 0)
        {
            sprite.color = unplaceableColor;
        } else
        {
            sprite.color = placeableColor;
        }

        rotationUpdate();
    }

}
