using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable
    {
        get
        {
            return isPlaceable;
        }
    }

    [SerializeField] private GameObject towerObject;

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
            Instantiate(towerObject, gameObject.transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
