using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class shoot : MonoBehaviour
{
    [SerializeField] public PlayerInput playerInput;
    private CinemachineImpulseSource impulseSource;

    [SerializeField] public Transform gunPoint;
    [SerializeField] public GameObject bullet;
    [SerializeField] public Light2D gunFire;
    [SerializeField] public float fireRate;
    [SerializeField] public bool triggerShot = true;


    void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
        gunFire.enabled = false;
    }

    public void OnShoot()
    {
        if (triggerShot && game_manager.instance.playerControlManager.controlable && game_manager.instance.playerControlManager.canShoot)
        {
            sounds_manager.intance.playSFX(soundType.GUNFIRE, 0.2f);
            camera_shake_manager.instance.cameraShake(impulseSource);
            GameObject bullets = Instantiate(bullet, gunPoint.position, Quaternion.identity);
            Rigidbody2D brb = bullets.GetComponent<Rigidbody2D>();
            brb.AddForce(gunPoint.up * 2f, ForceMode2D.Impulse);
            game_manager.instance.weaponManager.depleteAmmo();
            StartCoroutine(fireSpark());
            StartCoroutine(shootCooldown());
        } else if (triggerShot && game_manager.instance.weaponManager.isEmpty())
        {
            game_manager.instance.soundsManager.playSFX(soundType.EMPTY_SHOT, 1f);
            Debug.Log("EMPTY");
            StartCoroutine(shootCooldown());
        }
    }


    // Fire muzzle effect
    IEnumerator fireSpark()
    {
        gunFire.enabled = true;
        yield return new WaitForSeconds(0.01f);
        gunFire.enabled = false;
    }
    // Cooldown time acts as gun's fire rate
    IEnumerator shootCooldown()
    {
        triggerShot = false;
        yield return new WaitForSeconds(fireRate);
        triggerShot = true;
    }
}