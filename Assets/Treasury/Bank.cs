using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [Tooltip("Starting balance of the player")][SerializeField] private int startingBalance = 200;
    [SerializeField] public int currentBalance;
    //defining a property to make the the current balance more accessable 
    public int BalanceCheck { get { return currentBalance; } }

    [Tooltip("UI Tool to display balance on game screen")][SerializeField] private TextMeshProUGUI displayBalance;
    //Uniy is awakened
    void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }
    
    //To deposit money upon defeating enemy
    public void Deposit(int bonus)
    {
        currentBalance += Mathf.Abs(bonus); 
        UpdateDisplay();
    }

    //To withdraw money
    public void Withdraw(int expense)
    {
        currentBalance -= Mathf.Abs(expense);
        UpdateDisplay();

        if (currentBalance < 0)
        {
            //lose the game
            Debug.Log("Empire fell");
            ReloadLevel();
        }
    }

    //To update the gold balance on the game screen
    void UpdateDisplay()
    {
        displayBalance.text = "Gold: "+ currentBalance;
    }
    //To reload the level whenever needed
    void ReloadLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
