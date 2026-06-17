using UnityEngine;
using Unity.Cinemachine;


public class camera_shake_manager : MonoBehaviour
{
    public static camera_shake_manager instance;
    [SerializeField] public float force = 1f;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    public void cameraShake(CinemachineImpulseSource impulseSource)
    {
        impulseSource.GenerateImpulseWithForce(force);
    }
}
