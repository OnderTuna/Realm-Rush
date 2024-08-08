using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] private int totalValue = 150;
    [SerializeField] private int currentValue;
    public int CurrentValue
    {
        get
        {
            return currentValue;
        }
    }

    private void Awake()
    {
        currentValue = totalValue;
    }

    public void Deposit(int value)
    {
        currentValue += Mathf.Abs(value);
    }

    public void Withdraw(int value)
    {
        currentValue -= Mathf.Abs(value);

        if(currentValue < 0)
        {
            ReloadTheScene();
        }
    }

    private void ReloadTheScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
