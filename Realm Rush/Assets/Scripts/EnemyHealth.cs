using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int enemyHealth = 5;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        enemyHealth--;
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
