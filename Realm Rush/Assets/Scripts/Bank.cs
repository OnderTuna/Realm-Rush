using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
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
        GoldTextUI();
    }

    public void Deposit(int value)
    {
        currentValue += Mathf.Abs(value);
        GoldTextUI();
    }

    public void Withdraw(int value)
    {
        currentValue -= Mathf.Abs(value);
        GoldTextUI();

        if (currentValue < 0)
        {
            ReloadTheScene();
        }
    }

    private void GoldTextUI()
    {
        scoreText.text = $"Gold: {currentValue}";
    }

    private void ReloadTheScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
