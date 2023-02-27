using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [Tooltip("Starting balance of the player")][SerializeField] private int startingBalance = 200;
    [SerializeField] public int currentBalance;
    //defining a property to make the the current balance more accessable 
    public int BalanceCheck { get { return currentBalance; } }

    //Uniy is awakened
    void Awake()
    {
        currentBalance = startingBalance;
    }
    
    //To deposit money upon defeating enemy
    public void Deposit(int bonus)
    {
        currentBalance += Mathf.Abs(bonus); 
    }

    //To withdraw money
    public void Withdraw(int expense)
    {
        currentBalance -= Mathf.Abs(expense);

        if (currentBalance < 0)
        {
            //lose the game
            Debug.Log("Empire fell");
            ReloadLevel();
        }
    }

    //To reload the level whenever needed
    void ReloadLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
