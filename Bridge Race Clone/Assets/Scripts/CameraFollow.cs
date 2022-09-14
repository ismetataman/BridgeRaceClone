using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    public PlayerController playercontroller;
    public Transform cameraLastPos;
    private void FixedUpdate() 
    {
        
        transform.position = Vector3.Lerp(transform.position,target.position + offset,Time.deltaTime * 2);
        
        if(playercontroller.finishGame == true)
        {
            transform.position = Vector3.Lerp(transform.position,cameraLastPos.position,Time.deltaTime *2);
            transform.rotation = Quaternion.Euler(30,0,0);
        }
        
    }   
}
