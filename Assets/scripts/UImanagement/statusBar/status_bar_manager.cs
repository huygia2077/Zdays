using UnityEngine;
using UnityEngine.UI;

public class status_bar_manager : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Image ammoBar;
    [SerializeField] private health playerHealth;
    [SerializeField] private weapon_manager weaponManager;

    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<health>();
        weaponManager = GameObject.Find("weaponsManager").GetComponent<weapon_manager>();
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, playerHealth.currentHealth/playerHealth.maxHealth, 0.7f*Time.deltaTime);
        ammoBar.fillAmount = (float)weaponManager.ammo/weaponManager.maxAmmo;
    }
}
