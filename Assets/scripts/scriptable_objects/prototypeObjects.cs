using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class prototypeObjects : MonoBehaviour
{
    [SerializeField] public Camera cam;
    [SerializeField] public SpriteRenderer sprite;
    [SerializeField] public Color placeableColor;
    [SerializeField] public Color unplaceableColor;
    [SerializeField] public GameObject placedObject;
    private int collisionCount = 0;
    void Start()
    {
        BoxCollider2D bc =transform.AddComponent<BoxCollider2D>();
        bc.isTrigger = true;
        cam = Camera.main;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("obstacle") || other.CompareTag("solid_obstacle"))
        {
            collisionCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("obstacle") || other.CompareTag("solid_obstacle"))
        {
            collisionCount--;
            collisionCount = Mathf.Max(0, collisionCount);
        }
    }

    public void OnPlace()
    {
        if (!(collisionCount > 0))
        {
            Instantiate(placedObject, transform.position, Quaternion.identity);
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

    }
}
