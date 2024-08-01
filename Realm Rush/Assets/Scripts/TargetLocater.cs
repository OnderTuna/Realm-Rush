using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    private Transform target;


    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }
    
    void Update()
    {
        AimWeapon();
    }


    private void AimWeapon()
    {
        weapon.transform.LookAt(target);
    }
}
