using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private Text zombieKilled;
    [SerializeField] private Text days;


    public int budget = 500;
    [SerializeField] private int killCounts = 0;
    [SerializeField] private int survivedDays = 0;
    [SerializeField] private Text[] budgetDisplay;


    void Start()
    {
        instance = this;
        updateBudget();
    }

    private void updateBudget()
    {
        foreach (Text text in budgetDisplay)
        {   
            text.text = budget.ToString() + " $";
        }
    }
    public void changeBudget(int amount)
    {
        budget += amount;
        budget = (budget <= 0) ? 0 : budget;

        updateBudget();
    }


    public void addKillCount(int amount)
    {
        killCounts += amount;
    }


    // Trigger gameover screen
    public void triggerGameover()
    {
        gameoverUI.SetActive(true);
        gameoverAnimation.SetTrigger("gameover");
        days.text = "Survived days: " + survivedDays.ToString();
        zombieKilled.text = "Zombies killed: " + killCounts.ToString();
    }
}
