using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class weapon_manager : MonoBehaviour
{
    [SerializeField] public int ammo;
    [SerializeField] public int maxAmmo;
    [SerializeField] private Text ammoDisplay;
    public bool canShoot = true;

    public void reload()
    {
        canShoot = false;
        StartCoroutine(reloading(3f));
    }
    public void depleteAmmo()
    {
        ammo -= 1;
        if (ammo <= 0)
        {
            reload();
        }
    }

    void Update()
    {
        ammoDisplay.text = ammo.ToString();
    }


    IEnumerator reloading(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
        ammo = maxAmmo;
    }
}
