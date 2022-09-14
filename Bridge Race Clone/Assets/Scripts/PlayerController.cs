using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick _joystick;
    public float _moveSpeed;
    public bool gameStart;
    public bool respawnObject = false;
    public Animator _anim;
    private Rigidbody _rb;
    public bool finishGame = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        gameStart = false;
        finishGame = false;
    }

    private void FixedUpdate()
    {
        if(finishGame == false)
        {
            if(_joystick.Horizontal != 0 && _joystick.Vertical !=0)
            {
                gameStart = true;
                _rb.isKinematic =false;
                _rb.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rb.velocity.y, _joystick.Vertical * _moveSpeed);
                transform.rotation = Quaternion.LookRotation(_rb.velocity);
                _anim.SetBool("canRun",true);
            }
            
            if(_joystick.Horizontal == 0 && _joystick.Vertical ==0)
            {
                _rb.isKinematic = true;
                _anim.SetBool("canRun",false);
            }
            if(_joystick.Vertical <0)
            {
                _moveSpeed = 12;
            }
        }
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("DeadZone"))
        {
            Debug.Log("Dead Zone çalıştı");
        }
    }
   
    
}
