using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BotController : MonoBehaviour
{
    [SerializeField] private bool closest,furthest;
    [SerializeField] private Vector3 destination;
    public Transform[] finalDestination;
    public int index;
    public PlayerController playercontroller;
    public LayerMask layers;
    private NavMeshAgent agent;
    private Rigidbody _rb;
    public Animator _anim;


    void Start()
    {
        agent =GetComponent<NavMeshAgent>();
        _rb =GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        index = Random.Range(0,3);

    }

    void Update()
    {
        if(playercontroller.gameStart == true)
        {
            FindCollectables();
        }
    }
    public void FindCollectables()
    {
        Collider[] objectsInArea = Physics.OverlapSphere(transform.position,10f,layers);
        if(objectsInArea.Length >0)
        {
            _anim.SetBool("canRun",true);
            if(closest)
            {
                destination = objectsInArea[objectsInArea.Length -1].transform.position;
                agent.SetDestination(destination);
                if(StackList.instance.greenStack.Count > 0)
                {
                    GameObject.Find("GreenStack").transform.GetChild(GameObject.Find("GreenStack").transform.childCount -1).gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                if(StackList.instance.greenStack.Count > 3)
                {
                    agent.SetDestination(finalDestination[index].transform.position);
                }
                
            }
            if(furthest)
            {
                destination = objectsInArea[0].transform.position;
                agent.SetDestination(destination);
                if(StackList.instance.greenStack.Count > 0)
                {
                    GameObject.Find("GreenStack").transform.GetChild(GameObject.Find("GreenStack").transform.childCount -1).gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                if(StackList.instance.greenStack.Count > 8)
                {
                    agent.SetDestination(finalDestination[index].transform.position);
                }
            }
        }

        else if(objectsInArea.Length == 0 && StackList.instance.greenStack.Count == 0)
        {
            agent.SetDestination(new Vector3(0,0.26f,-7.5f));
        }
       
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Door"))
        {
            index = 3;
            agent.SetDestination(finalDestination[3].transform.position);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(this.transform.position,10f);
    }
    
}
