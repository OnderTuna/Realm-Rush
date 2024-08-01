using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path;
    IEnumerator followNumerator;
    [SerializeField][Range(0f, 5f)] private float speed = 1f;

    private void Awake()
    {
        FindPath();
    }

    void Start()
    {
        followNumerator = FollowPath();
        StartCoroutine(followNumerator);
        ReturnToStart();
    }

    void Update()
    {
        
    }

    private void FindPath()
    {
        path.Clear();

        GameObject parentPath = GameObject.FindGameObjectWithTag("Paths");
        foreach (Transform child in parentPath.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if(waypoint != null)
            {
                path.Add(waypoint);
            }
        }
    }

    private IEnumerator FollowPath()
    {
        for (int i = 0; i < path.Count; i++)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = path[i].transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPos);

            while (travelPercent < 1)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        Destroy(gameObject);
    }

    private void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
}
