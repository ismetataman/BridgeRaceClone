using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBotStairMaker : MonoBehaviour
{
    public GameObject StackObject;
    public BlueStackController bluestackcontroller;
    public GameObject blueCube;
    public PlayerController playercontroller;
    
    void Update()
    {
        if(StackList.instance.blueStack.Count == 0)
        {
            bluestackcontroller.stackPos = Vector3.zero;
        }
        if(playercontroller.finishGame == true)
        {
            if(StackList.instance.blueStack.Count > 0)
            {
                for (int i = 0; i < StackList.instance.blueStack.Count; i++)
                {   
                    StackList.instance.blueStack.RemoveAt(i);
                    Destroy(StackObject.transform.GetChild(i).gameObject);
                    Debug.Log(i + " mavi siindi");
                }
                
            }
            
        }
    }
     private void OnCollisionEnter(Collision other) 
    {
        int numOfChild = StackObject.transform.childCount;
        if(other.gameObject.CompareTag("Stair"))
        {
            if(StackList.instance.blueStack.Count >0)
            {
                StackList.instance.blueStack.RemoveAt(StackList.instance.blueStack.Count -1);
                GameObject go = Instantiate(blueCube,StackObject.transform.GetChild(numOfChild -1).gameObject.GetComponent<ObjectSpawner>().startPosition,Quaternion.identity);
                go.transform.parent = GameObject.Find("BlueCubes").transform;
                bluestackcontroller.stackPos -= new Vector3(0,0.5f,0);
                Destroy(StackObject.transform.GetChild(numOfChild -1).gameObject);
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
                other.gameObject.GetComponent<Renderer>().material = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
                other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                other.gameObject.tag = "blueStair";
            }
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("redStair") || other.gameObject.CompareTag("greenStair"))
        {
            int numOfChild = StackObject.transform.childCount;
             if(StackList.instance.blueStack.Count >0)
            {
                StackList.instance.blueStack.RemoveAt(StackList.instance.blueStack.Count -1);
                GameObject go = Instantiate(blueCube,StackObject.transform.GetChild(numOfChild -1).gameObject.GetComponent<ObjectSpawner>().startPosition,Quaternion.identity);
                go.transform.parent = GameObject.Find("BlueCubes").transform;
                bluestackcontroller.stackPos -= new Vector3(0,0.5f,0);
                Destroy(StackObject.transform.GetChild(numOfChild -1).gameObject);
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
                other.gameObject.GetComponent<Renderer>().material = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
                other.gameObject.tag = "blueStair";
            }
        }
    }
}
