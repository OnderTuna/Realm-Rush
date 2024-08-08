using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int rewardValue = 25;
    [SerializeField] private int goldPenalty = 25;
    Bank bankScript;

    private void Awake()
    {
        bankScript = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        if (bankScript == null)
        {
            return;
        }
        else
        {
            bankScript.Deposit(rewardValue);
        }
    }

    public void StealGold()
    {
        if(bankScript == null)
        {
            return;
        }
        else
        {
            bankScript.Withdraw(goldPenalty);
        }
    }
}
