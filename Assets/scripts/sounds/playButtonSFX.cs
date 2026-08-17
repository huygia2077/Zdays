using UnityEngine;

public class playButtonSFX : MonoBehaviour
{
    [SerializeField] private soundType SFX;
    [SerializeField] float vol;
    public void playClickSFX()
    {
        sounds_manager.intance.playSFX(SFX, vol);
    }
}
