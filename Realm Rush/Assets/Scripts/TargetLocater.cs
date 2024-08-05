using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private float maxRange = 15f;
    [SerializeField] private ParticleSystem fireEffect;
    private Transform target;


    void Start()
    {

    }

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies;
        enemies = FindObjectsOfType<Enemy>();
        Transform closestEnemy = null;
        float maxDistance = Mathf.Infinity;

        for (int i = 0; i < enemies.Length; i++)
        {
            float targetDistance = Vector3.Distance(transform.position, enemies[i].transform.position);
            if (targetDistance < maxDistance)
            {
                closestEnemy = enemies[i].transform;
                maxDistance = targetDistance;
            }
        }

        target = closestEnemy;
    }

    private void AimWeapon()
    {
        float rangeCheck = Vector3.Distance(transform.position, target.transform.position);
        weapon.transform.LookAt(target);

        if (rangeCheck < maxRange)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    private void Attack(bool value)
    {
        ParticleSystem.EmissionModule emissionModule = fireEffect.emission;
        emissionModule.enabled = value;
    }
}
