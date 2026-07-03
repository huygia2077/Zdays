using UnityEngine;
using UnityEngine.UI;

public class status_bar_manager : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Image damageBar;
    [SerializeField] private Image ammoBar;
    [SerializeField] private player_health playerHealth;
    [SerializeField] private weapon_manager weaponManager;

    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<player_health>();
        weaponManager = GameObject.Find("weaponsManager").GetComponent<weapon_manager>();
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, playerHealth.currentHealth/playerHealth.maxHealth, 0.7f*Time.deltaTime);
        ammoBar.fillAmount = (float)weaponManager.ammo/weaponManager.maxAmmo;
        if (healthBar.fillAmount != damageBar.fillAmount)
        {
            damageBar.fillAmount = Mathf.MoveTowards(damageBar.fillAmount, healthBar.fillAmount, 0.3f*Time.deltaTime);
        }
    }
}
