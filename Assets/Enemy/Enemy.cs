using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("Enemy's worth")][SerializeField] int goldReward = 25;
    [Tooltip("Enemy's loot from the player ")][SerializeField] int goldPenalty = 20;

    Bank bank;
    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    //To reward the player on enemy destruction
    public void RewardGold()
    {
        if (bank == null) { return; } //failsafe to ensure the bank is available
        bank.Deposit(goldReward);
    }

    //To fine the player on failure to guard against the enemy
    public void PayFine()
    {
        if (bank == null) { return; } //failsafe to ensure the bank is available
        bank.Withdraw(goldPenalty);
    }
}
