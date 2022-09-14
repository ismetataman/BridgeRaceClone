using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BotStackController : MonoBehaviour
{
    public Vector3 stackPos;
    public int totalCubeTaken=0;
   private void Start() 
   {
        stackPos = Vector3.zero; 
   }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("green"))
        {
            totalCubeTaken++;
            StackList.instance.greenStack.Add(other.gameObject);
            other.gameObject.transform.parent = GameObject.Find("GreenStack").transform;
            other.transform.DOLocalMove(stackPos,0.2f);
            other.transform.DOLocalRotate(stackPos,0.2f);
            stackPos += new Vector3(0,0.5f,0);

            Debug.Log("Stack Alındı");
        }
        
    }
}
