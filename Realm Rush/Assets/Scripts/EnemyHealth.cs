using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int currentHealth = 0;
    private int maxHealth = 5;
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
            gameObject.SetActive(false);
        }
    }
}
