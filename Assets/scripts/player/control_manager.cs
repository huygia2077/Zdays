using UnityEngine;

public class control_manager : MonoBehaviour
{
    public bool controlable = true; // Permision to move
    public bool canShoot = true; // Permision to shoot

    public void disableShootin()
    {
        canShoot = false;
    }

    public void enableShootin()
    {
        canShoot = true;
    }
}
