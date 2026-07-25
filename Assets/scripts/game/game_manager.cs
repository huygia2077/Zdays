using UnityEngine;
using UnityEngine.UI;

public class game_manager : MonoBehaviour
{
    // Create singleton intance
    public static game_manager instance;

    // Managers scipt;
    [Space(10)]
    [Header("Manger Scripts")]
    [SerializeField] public prototype_manager prototypeManager;
    [SerializeField] public obstacles_manager obstacleManager;
    [SerializeField] public zombie_spawn_manager zombieSpawnerManager;
    [SerializeField] public weapon_manager weaponManager;
    [SerializeField] public shop_manager shopManager;
    [SerializeField] public control_manager playerControlManager;
    [SerializeField] public sounds_manager soundsManager;

    // Managing gameover UI
    [Space(10)]
    [Header("Gameover UI & Animations")]
    [SerializeField] private Animator gameoverAnimation;
    [SerializeField] private GameObject gameoverUI;
    [SerializeField] private Text zombieKilled;
    [SerializeField] private Text daysPassed;

    // Managing new day and reward UI   
    [Space(10)]
    [Header("Days passed and reward UI")]
    [SerializeField] private Animator daysAndRewards;
    [SerializeField] private Text day;

    // Statistic
    [Space(10)]
    [Header("Survied days statistic")]
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
        daysPassed.text = "Survived days: " + survivedDays.ToString();
        zombieKilled.text = "Zombies killed: " + killCounts.ToString();
    }


    // Trigger new day animation
    public void startNewDay()
    {
        survivedDays++;
        daysAndRewards.SetTrigger("startNewDay");
    }
    public void updateDaysAndRewards()
    {
        day.text = "Day " + survivedDays.ToString();
    }
}
