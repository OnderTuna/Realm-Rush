using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(isPlaceable)
        {
            Debug.Log(gameObject.transform.name);
        }
    }
}
