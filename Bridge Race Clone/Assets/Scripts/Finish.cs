using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class Finish : MonoBehaviour
{
    public Transform firstPlace;
    public Transform secondPlace;
    public Transform thirdPlace;
    public PlayerController playercontroller;
    public StackController stackcontroller;
    public BotController botcontroller;
    public BlueBotController bluebotcontroller;
    public BlueStackController bluestackcontroller;
    public BotStackController botstackcontroller;
    public GameObject completed;
    public GameObject effect;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {  
            completed.SetActive(true);
            effect.SetActive(true);
            playercontroller.finishGame = true;
            playercontroller.gameStart = false;
            playercontroller._anim.SetBool("canRun",false);
            playercontroller._anim.Play("dance");
            botcontroller._anim.SetBool("canRun",false);
            botcontroller._anim.Play("loseDance");
            bluebotcontroller._anim.SetBool("canRun",false);
            bluebotcontroller._anim.Play("loseDance");
            other.gameObject.GetComponent<NavMeshAgent>().enabled =false;
            GameObject.Find("BlueBot").gameObject.GetComponent<NavMeshAgent>().enabled=false;
            GameObject.Find("GreenBot").gameObject.GetComponent<NavMeshAgent>().enabled=false;
            other.gameObject.transform.DOMove(firstPlace.position,0.2f);
            other.transform.DORotate(new Vector3(0,180,0),0);
            GameObject.Find("BlueBot").gameObject.transform.DORotate(new Vector3(0,180,0),0);
            GameObject.Find("GreenBot").gameObject.transform.DORotate(new Vector3(0,180,0),0);

            if(bluestackcontroller.totalCubeTaken > botstackcontroller.totalCubeTaken)
            {
                GameObject.Find("BlueBot").gameObject.transform.DOMove(secondPlace.position,0.3f);
                GameObject.Find("GreenBot").gameObject.transform.DOMove(thirdPlace.position,0.3f);
            }
            else 
            {
                GameObject.Find("BlueBot").gameObject.transform.DOMove(thirdPlace.position,0.3f);
                GameObject.Find("GreenBot").gameObject.transform.DOMove(secondPlace.position,0.3f);
            }
            
        }
        if(other.gameObject.CompareTag("GreenBot"))
        {  
            completed.SetActive(true);
            playercontroller.finishGame = true;
            playercontroller.gameStart = false;
            playercontroller._anim.SetBool("canRun",false);
            playercontroller._anim.Play("loseDance");
            botcontroller._anim.SetBool("canRun",false);
            botcontroller._anim.Play("dance");
            bluebotcontroller._anim.SetBool("canRun",false);
            bluebotcontroller._anim.Play("loseDance");
            other.gameObject.GetComponent<NavMeshAgent>().enabled =false;
            GameObject.Find("BlueBot").gameObject.GetComponent<NavMeshAgent>().enabled=false;
            GameObject.Find("Player").gameObject.GetComponent<NavMeshAgent>().enabled=false;
            other.gameObject.transform.DOMove(firstPlace.position,0.2f);
            other.transform.DORotate(new Vector3(0,180,0),0);
            GameObject.Find("BlueBot").gameObject.transform.DORotate(new Vector3(0,180,0),0);
            GameObject.Find("Player").gameObject.transform.DORotate(new Vector3(0,180,0),0);

            if(stackcontroller.totalCubeTaken > bluestackcontroller.totalCubeTaken)
            {
                GameObject.Find("Player").gameObject.transform.DOMove(secondPlace.position,0.3f);
                GameObject.Find("BlueBot").gameObject.transform.DOMove(thirdPlace.position,0.3f);
            }
            else
            {
                GameObject.Find("Player").gameObject.transform.DOMove(thirdPlace.position,0.3f);
                GameObject.Find("BlueBot").gameObject.transform.DOMove(secondPlace.position,0.3f);
            }
        }
        if(other.gameObject.CompareTag("BlueBot"))
        {  
            completed.SetActive(true);
            playercontroller.finishGame = true;
            playercontroller.gameStart = false;
            playercontroller._anim.SetBool("canRun",false);
            playercontroller._anim.Play("loseDance");
            botcontroller._anim.SetBool("canRun",false);
            botcontroller._anim.Play("loseDance");
            bluebotcontroller._anim.SetBool("canRun",false);
            bluebotcontroller._anim.Play("dance");
            other.gameObject.GetComponent<NavMeshAgent>().enabled =false;
            GameObject.Find("GreenBot").gameObject.GetComponent<NavMeshAgent>().enabled=false;
            GameObject.Find("Player").gameObject.GetComponent<NavMeshAgent>().enabled=false;
            other.gameObject.transform.DOMove(firstPlace.position,0.2f);
            other.transform.DORotate(new Vector3(0,180,0),0);
            GameObject.Find("GreenBot").gameObject.transform.DORotate(new Vector3(0,180,0),0);
            GameObject.Find("Player").gameObject.transform.DORotate(new Vector3(0,180,0),0);

            if(stackcontroller.totalCubeTaken > botstackcontroller.totalCubeTaken)
            {
                GameObject.Find("Player").gameObject.transform.DOMove(secondPlace.position,0.3f);
                GameObject.Find("GreenBot").gameObject.transform.DOMove(thirdPlace.position,0.3f);
            }
            else
            {
                GameObject.Find("Player").gameObject.transform.DOMove(thirdPlace.position,0.3f);
                GameObject.Find("GreenBot").gameObject.transform.DOMove(secondPlace.position,0.3f);
            }
            
        }
    }
}
