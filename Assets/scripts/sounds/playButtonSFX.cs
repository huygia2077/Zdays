using UnityEngine;

public class playButtonSFX : MonoBehaviour
{
    public void playClickSFX()
    {
        sounds_manager.intance.playSFX(soundType.TICK, 0.2f);
    }
}
