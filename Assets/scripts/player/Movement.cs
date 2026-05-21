using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour

{
    [SerializeField] public float speed;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform tf;
    [SerializeField] public PlayerInput playerInput;
    [SerializeField] public Camera cam;


    private Vector2 movementDirection;
    private Vector2 mousePosition;

    public void OnMove(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }

    public void FixedUpdate()
    {
        rb.linearVelocity = movementDirection * speed ;

        Vector3 worldPos = cam.ScreenToWorldPoint(mousePosition);
        Vector2 lookDirection = worldPos - tf.position;

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        tf.rotation = Quaternion.Euler(0, 0, angle);
    }
}
