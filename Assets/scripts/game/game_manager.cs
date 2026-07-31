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
    [SerializeField] public save_manager savedManager;

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
    [SerializeField] private Animator rewardAnimation;
    [SerializeField] private Text day;
    [SerializeField] private Text reward;
    public bool startingNewWave = true;

    // Statistic
    [Space(10)]
    [Header("Survied days statistic")]
    [SerializeField] private int killCounts = 0;
    [SerializeField] private int survivedDays = 0;
    [SerializeField] private int rewards = 200;


    void Start()
    {
        instance = this;
    }

    
    // Count how many kills player got
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
        if (startingNewWave)
        {
            survivedDays++;
            daysAndRewards.SetTrigger("startNewDay");
            startingNewWave = false;
        }
    }   
    // Update Day UI text
    public void updateDays()
    {
        day.text = "Day " + survivedDays.ToString();
    }


    // Adding reward and trigger the reward animation
    public void addRewards()
    {
        rewardAnimation.SetTrigger("addRewards");
        reward.text = "+" + rewards.ToString() + "$";
        shopManager.addMoney(rewards);

    }
}
