using UnityEngine;

public class game_manager : MonoBehaviour
{
    // Create singleton intance
    public static game_manager instance;

    // Managers scipt;
    [SerializeField] public prototype_manager prototypeManager;
    [SerializeField] public obstacles_manager obstacleManager;
    [SerializeField] public zombie_spawn_manager zombieSpawnerManager;
    [SerializeField] public weapon_manager weaponManager;
    [SerializeField] public shop_manager shopManager;
    [SerializeField] public control_manager playerControlManager;
    [SerializeField] public sounds_manager soundsManager;

    // Managing gameover UI
    [SerializeField] private Animator gameoverAnimation;
    [SerializeField] private GameObject gameoverUI;


    void Start()
    {
        instance = this;
    }


    // Trigger gameover screen
    public void triggerGameover()
    {
        gameoverUI.SetActive(true);
        gameoverAnimation.SetTrigger("gameover");
    }
}
