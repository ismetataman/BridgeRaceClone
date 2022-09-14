using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject redCubesParent;
    public GameObject greenCubesParent;
    public GameObject blueCubesParent;
    public GameObject part1,part2,part3,part4;

    private void Start() 
    {
        gameObject.GetComponent<Renderer>();
    }
   private void OnTriggerEnter(Collider other) 
   {
        if(other.gameObject.CompareTag("Player"))
        {
           part1.gameObject.transform.GetComponent<Renderer>().material = other.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
           part2.gameObject.transform.GetComponent<Renderer>().material = other.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
           part3.gameObject.transform.GetComponent<Renderer>().material = other.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
           part4.gameObject.transform.GetComponent<Renderer>().material = other.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
           redCubesParent.SetActive(true);
        }
        if(other.gameObject.CompareTag("GreenBot"))
        {
           part1.gameObject.transform.GetComponent<Renderer>().material = other.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
           part2.gameObject.transform.GetComponent<Renderer>().material = other.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
           part3.gameObject.transform.GetComponent<Renderer>().material = other.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
           part4.gameObject.transform.GetComponent<Renderer>().material = other.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;

           greenCubesParent.SetActive(true);
        }
        if(other.gameObject.CompareTag("BlueBot"))
        {
           part1.gameObject.transform.GetComponent<Renderer>().material = other.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
           part2.gameObject.transform.GetComponent<Renderer>().material = other.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
           part3.gameObject.transform.GetComponent<Renderer>().material = other.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
           part4.gameObject.transform.GetComponent<Renderer>().material = other.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material;
           blueCubesParent.SetActive(true);
        }
   }
}
