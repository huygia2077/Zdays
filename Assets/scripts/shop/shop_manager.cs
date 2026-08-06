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
        float duration = 0.5f; // How long the animation takes in seconds
        float elapsedTime = 0f;

        while (elapsedTime < duration) 
        {
            // Increase elapsed time by the time passed since the last frame
            elapsedTime += Time.deltaTime;
            
            // Calculate the current value based on how much time has passed
            float currentLerp = Mathf.Lerp(oldBudget, currentBudget, elapsedTime / duration);
            int displayValue = Mathf.RoundToInt(currentLerp);
            
            foreach (Text text in budgetDisplay)
            {
                text.text = displayValue.ToString() + " $";
            }
                
            yield return null;
        }

        // Failsafe: Ensure it ends exactly on the target number
        foreach (Text text in budgetDisplay)
        {
            text.text = currentBudget.ToString() + " $";
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
