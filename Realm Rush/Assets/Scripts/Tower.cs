using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private int towerCost = 50;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public bool CreateTower(Tower towerPrefab, Vector3 createPos, Quaternion createRotation)
    {
        Bank bank = FindObjectOfType<Bank>();

        if(bank == null)
        {
            return false;
        }

        if(bank.CurrentValue >= towerCost)
        {
            Instantiate(towerPrefab, createPos, createRotation);
            bank.Withdraw(towerCost);
            return true;
        }
        else
        {
            return false;
        }
    }
}
