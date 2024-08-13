using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    private int currentHealth = 0;
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int difficultyRamp = 1;
    Enemy enemyScript;

    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        enemyScript = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHealth--;
        if(currentHealth <= 0)
        {
            enemyScript.RewardGold();
            maxHealth += difficultyRamp;
            gameObject.SetActive(false);
        }
    }
}
