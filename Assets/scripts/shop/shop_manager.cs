using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class shop_manager : MonoBehaviour
{
    [SerializeField] private Animator shopAnimation;
    [SerializeField] public int budget = 0;
    [SerializeField] private Text[] budgetDisplay;
    private WaitForSeconds budgetUpdatingTime = new WaitForSeconds(0.01f);


    void Start()
    {
        updateBudget(0, budget);
    }

    private void updateBudget(int oldBudget, int currentBudget)
    {
        StartCoroutine(updatingBudgetDisplay(oldBudget, currentBudget));
    }
    public void purchaseCost(int amount)
    {
        int oldBudget = budget;
        budget -= amount;
        budget = (budget <= 0) ? 0 : budget;
        updateBudget(oldBudget, budget);
    }
    public void addMoney(int amount)
    {
        int oldBudget = budget;
        budget += amount;
        updateBudget(oldBudget, budget);
    }


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

    public void openShop()
    {
        game_manager.instance.playerControlManager.controlable = false;
        shopAnimation.SetTrigger("openShop");
        game_manager.instance.prototypeManager.disablePrototype();
    }
    public void closeShop()
    {
        game_manager.instance.playerControlManager.controlable = true;
        shopAnimation.SetTrigger("closeShop");
    }
}
