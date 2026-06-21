using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class weapon_manager : MonoBehaviour
{
    [SerializeField] public int ammo;
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
    }

    void Update()
    {
        ammoDisplay.text = ammo.ToString();
        if (ammo <= 0)
        {
            reload();
        }
    }


    IEnumerator reloading(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
        ammo = 30;
    }
}
