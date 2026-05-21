using UnityEngine;
using Unity.Cinemachine;


public class cameraShakeManager : MonoBehaviour
{
    public static cameraShakeManager instance;
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
