using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Tooltip("Cost of building a tower")][SerializeField] int towerExpense = 60;
    
    //To build the tower for player
    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();
        if (bank == null) { return false;}

        if (bank.currentBalance >= towerExpense)
        {
            Instantiate(tower, position, Quaternion.identity);
            bank.Withdraw(towerExpense);
            return true;
        }
        return false;
        
    }
}
