using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class obstacles_manager : MonoBehaviour
{
    [Header("Destroy object toggling button")]
    [SerializeField] private bool destroyable = false; 
    [SerializeField] private Image destroyObjectButton;
    [SerializeField] private Color disabledColor, enabledColor;

    public void disableDestroyMode()
    {
        destroyable = false;
        destroyObjectButton.color = destroyable ? enabledColor : disabledColor;
    }

    public void toggleDestoryMode()
    {
        destroyable = !destroyable;
        destroyObjectButton.color = destroyable ? enabledColor : disabledColor;
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
