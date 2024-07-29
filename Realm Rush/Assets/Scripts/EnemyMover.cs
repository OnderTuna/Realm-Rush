using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path;
    IEnumerator followNumerator;
    private float delayTime = 1f;

    void Start()
    {
        followNumerator = FollowPath();
        StartCoroutine(followNumerator);
    }
    
    void Update()
    {
        
    }

    private IEnumerator FollowPath()
    {
        for (int i = 0; i < path.Count; i++)
        {
            transform.position = path[i].transform.position;
            yield return new WaitForSeconds(delayTime);
        }
    }
}
