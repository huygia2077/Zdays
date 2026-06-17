using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour

{
    [SerializeField] public float speed;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform tf;
    [SerializeField] public Camera cam;
    private control_manager controlManager;
    private Vector2 movementDirection;
    private Vector2 mousePosition;

    void Start()
    {
        controlManager = gameObject.GetComponent<control_manager>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }

    public void Update()
    {
        if (controlManager.controlable)
        {
            rb.linearVelocity = movementDirection * speed ;

            Vector3 worldPos = cam.ScreenToWorldPoint(mousePosition);
            Vector2 lookDirection = worldPos - tf.position;

            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            tf.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
