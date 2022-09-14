using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackList : MonoBehaviour
{
    public static StackList instance;
    public List <GameObject> stack = new List<GameObject>();
    public List <GameObject> greenStack = new List<GameObject>();
    public List <GameObject> blueStack = new List<GameObject>();

    void Awake() 
    {
        instance = this;
    }
}
