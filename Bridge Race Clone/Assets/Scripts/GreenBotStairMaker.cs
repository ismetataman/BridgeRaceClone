using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBotStairMaker : MonoBehaviour
{
    public GameObject StackObject;
    public PlayerController playercontroller;
    public BotStackController botStackController;
    public GameObject greenCube;
    
    void Update()
    {
        if(StackList.instance.greenStack.Count == 0)
        {
            botStackController.stackPos = Vector3.zero;
        }
        if(playercontroller.finishGame == true)
        {
             if(StackList.instance.greenStack.Count > 0)
            {
                for (int i = 0; i < StackList.instance.greenStack.Count; i++)
                {   
                    StackList.instance.greenStack.RemoveAt(i);
                    Destroy(StackObject.transform.GetChild(i).gameObject);
                    Debug.Log(i + "yeşil siindi");
                }
                
            }
            
        }
        
    }
     private void OnCollisionEnter(Collision other) 
    {
        int numOfChild = StackObject.transform.childCount;
        if(other.gameObject.CompareTag("Stair"))
        {
            if(StackList.instance.greenStack.Count >0)
            {
                StackList.instance.greenStack.RemoveAt(StackList.instance.greenStack.Count -1);
                GameObject go = Instantiate(greenCube,StackObject.transform.GetChild(numOfChild -1).gameObject.GetComponent<ObjectSpawner>().startPosition,Quaternion.identity);
                go.transform.parent = GameObject.Find("GreenCubes").transform;
                botStackController.stackPos -= new Vector3(0,0.5f,0);
                Destroy(StackObject.transform.GetChild(numOfChild -1).gameObject);
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
                other.gameObject.GetComponent<Renderer>().material = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
                other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                other.gameObject.tag = "greenStair";
            }
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("redStair") || other.gameObject.CompareTag("blueStair"))
        {
            int numOfChild = StackObject.transform.childCount;
             if(StackList.instance.greenStack.Count >0)
            {
                StackList.instance.greenStack.RemoveAt(StackList.instance.greenStack.Count -1);
                GameObject go = Instantiate(greenCube,StackObject.transform.GetChild(numOfChild -1).gameObject.GetComponent<ObjectSpawner>().startPosition,Quaternion.identity);
                go.transform.parent = GameObject.Find("GreenCubes").transform;
                botStackController.stackPos -= new Vector3(0,0.5f,0);
                Destroy(StackObject.transform.GetChild(numOfChild -1).gameObject);
                other.gameObject.GetComponent<MeshRenderer>().enabled = true;
                other.gameObject.GetComponent<Renderer>().material = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
                other.gameObject.tag = "greenStair";
            }
        }
    }
}
