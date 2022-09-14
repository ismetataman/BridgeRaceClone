using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
   public Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
        //Debug.Log(startPosition);
    }
    
    
}
