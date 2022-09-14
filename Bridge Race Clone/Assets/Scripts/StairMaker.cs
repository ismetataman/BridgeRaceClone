using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairMaker : MonoBehaviour
{
    public PlayerController playercontroller;
    public GameObject StackObject;
    public StackController stackcontroller;
    public GameObject redCube;

    private void Update() 
    {
        if(StackList.instance.stack.Count == 0)
        {
            stackcontroller.stackPos = Vector3.zero;
        }
        if(playercontroller.finishGame == true)
        {
            if(StackList.instance.stack.Count > 0)
            {
                for (int i = 0; i < StackList.instance.stack.Count; i++)
                {   
                    StackList.instance.stack.RemoveAt(i);
                    Destroy(StackObject.transform.GetChild(i).gameObject);
                    Debug.Log(i + " kırmızı siindi");
                }
                
            }
            
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        int numOfChild = StackObject.transform.childCount;
        if(other.gameObject.CompareTag("Stair") || other.gameObject.CompareTag("greenStair"))
        {
            if(StackList.instance.stack.Count >0)
            {
                StackList.instance.stack.RemoveAt(StackList.instance.stack.Count -1);
                GameObject go = Instantiate(redCube,StackObject.transform.GetChild(numOfChild -1).gameObject.GetComponent<ObjectSpawner>().startPosition,Quaternion.identity);
                go.transform.parent = GameObject.Find("RedCubes").transform;
                stackcontroller.stackPos -= new Vector3(0,0.5f,0);
                Destroy(StackObject.transform.GetChild(numOfChild -1).gameObject);
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
                other.gameObject.GetComponent<Renderer>().material = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
                other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                other.gameObject.tag = "redStair";
            }
            
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("greenStair") || other.gameObject.CompareTag("blueStair"))
        {
            int numOfChild = StackObject.transform.childCount;
             if(StackList.instance.stack.Count >0)
            {
                StackList.instance.stack.RemoveAt(StackList.instance.stack.Count -1);
                GameObject go = Instantiate(redCube,StackObject.transform.GetChild(numOfChild -1).gameObject.GetComponent<ObjectSpawner>().startPosition,Quaternion.identity);
                go.transform.parent = GameObject.Find("RedCubes").transform;
                stackcontroller.stackPos -= new Vector3(0,0.5f,0);
                Destroy(StackObject.transform.GetChild(numOfChild -1).gameObject);
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
                other.gameObject.GetComponent<Renderer>().material = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
                other.gameObject.tag = "redStair";
            }
            if(StackList.instance.stack.Count == 0)
            {
                playercontroller._moveSpeed = 0;
            }
        }
    }
    

}
