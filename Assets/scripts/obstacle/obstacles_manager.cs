using UnityEngine;
using UnityEngine.InputSystem;

public class obstacles_manager : MonoBehaviour
{
    public bool destroyable = false;
    public void enableDestroy()
    {
        destroyable = true;
    }
    public void disableDestroy()
    {
        destroyable = false;
    }
    public void toggleDestoryMode()
    {
        destroyable = !destroyable;
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && destroyable)
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit2D raycastHit = Physics2D.Raycast(mouseRay.origin, Vector2.zero);
            GameObject clickedObject = raycastHit ? raycastHit.collider.gameObject : null;

            if (clickedObject)
            {
                clickedObject.GetComponent<obstacle>()?.removeObject();
            }
        }
    }
}
