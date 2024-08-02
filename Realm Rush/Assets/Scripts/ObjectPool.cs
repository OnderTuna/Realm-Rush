using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private float delayTime = 1f;
    IEnumerator spawnEnemy;

    void Start()
    {
        spawnEnemy = SpawnEnemy();
        StartCoroutine(spawnEnemy);
    }
    
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            Instantiate(enemy, transform);
            yield return new WaitForSeconds(delayTime);
        }
    }
}
