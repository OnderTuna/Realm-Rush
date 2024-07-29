using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path;

    void Start()
    {
        for (int i = 0; i < path.Count; i++)
        {
            Debug.Log($"Anlik olarak koordinatim: {path[i].transform.name}");
        }
    }
    
    void Update()
    {
        
    }
}
