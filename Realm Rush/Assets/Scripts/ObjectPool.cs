using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] [Range(0.1f, 30f)] float delayTime = 1f;
    IEnumerator spawnEnemy;
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    private GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        spawnEnemy = SpawnEnemy();
        StartCoroutine(spawnEnemy);
    }

    void Update()
    {

    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(delayTime);
        }
    }

    private void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
}
