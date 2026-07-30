using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class shop_manager : MonoBehaviour
{
    [SerializeField] private Animator shopAnimation;
    [SerializeField] public int budget = 0;
    [SerializeField] private Text[] budgetDisplay;
    private WaitForSeconds budgetUpdatingTime = new WaitForSeconds(0.01f);



    // Initialize budget UI text
    void Start()
    {
        updateBudget(0, budget);
    }


    // Update budget UI text
    private void updateBudget(int oldBudget, int currentBudget)
    {
        StartCoroutine(updatingBudgetDisplay(oldBudget, currentBudget));
    }


    // Budget gradually change effect
    private IEnumerator updatingBudgetDisplay(int oldBudget, int currentBudget)
    {
        while (oldBudget != currentBudget)
        {
            oldBudget += (oldBudget > currentBudget) ? -1 : 1;
            foreach (Text text in budgetDisplay)
            {   
                text.text = oldBudget.ToString() + " $";
            }
            yield return budgetUpdatingTime;
        }
    }


    // Purchase item action
    public void purchaseCost(int amount)
    {
        int oldBudget = budget;
        budget -= amount;
        budget = (budget <= 0) ? 0 : budget;
        updateBudget(oldBudget, budget);
    }


    // Add money to current budget (rewards)
    public void addMoney(int amount)
    {
        int oldBudget = budget;
        budget += amount;
        updateBudget(oldBudget, budget);
    }


    // Open shop
    public void openShop()
    {
        game_manager.instance.playerControlManager.controlable = false;
        shopAnimation.SetTrigger("openShop");
        game_manager.instance.prototypeManager.disablePrototype();
    }


    // Close shop
    public void closeShop()
    {
        game_manager.instance.playerControlManager.controlable = true;
        shopAnimation.SetTrigger("closeShop");
    }
}
