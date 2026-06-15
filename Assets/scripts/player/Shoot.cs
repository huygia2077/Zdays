using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class Shoot : MonoBehaviour
{
    [SerializeField] public PlayerInput playerInput;
    private CinemachineImpulseSource impulseSource;

    [SerializeField] public Transform gunPoint;
    [SerializeField] public GameObject bullet;
    [SerializeField] public Light2D gunFire;
    [SerializeField] public float fireRate;
    [SerializeField] public bool canShoot = true;
    private controlManager controlManager;


    void Start()
    {
        controlManager = gameObject.GetComponent<controlManager>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
        gunFire.enabled = false;
    }

    public void OnShoot()
    {
        if (canShoot && controlManager.controlable)
        {
            cameraShakeManager.instance.cameraShake(impulseSource);
            GameObject bullets = Instantiate(bullet, gunPoint.position, Quaternion.identity);
            Rigidbody2D brb = bullets.GetComponent<Rigidbody2D>();
            brb.AddForce(gunPoint.up * 2f, ForceMode2D.Impulse);
            StartCoroutine(fireSpark());
            StartCoroutine(shootCooldown());
        }
    }

    IEnumerator fireSpark()
    {
        gunFire.enabled = true;
        yield return new WaitForSeconds(0.01f);
        gunFire.enabled = false;
    }

    IEnumerator shootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}