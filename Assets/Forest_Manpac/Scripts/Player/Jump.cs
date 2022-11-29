using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour{
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public string JumpButton;
    private Vector3 JumpDirection = Vector3.zero;    
    CharacterController controller;
    public Animator _anim;



        void Awake() {
        controller = GetComponent<CharacterController>(); 
    }
    void Update() {
        Jumping();
        if (controller.isGrounded) {
            Debug.Log("puedes saltar");
            } 
     }   
        
     void Jumping() {
        if (controller.isGrounded) {
          _anim.SetBool("Jump", false);  
            if (Input.GetButton(JumpButton)){      
                JumpDirection.y = jumpSpeed;
            _anim.SetBool("Jump", true);
           }
    }    

        JumpDirection.y -= gravity * Time.deltaTime;
        controller.Move(JumpDirection * Time.deltaTime);
    }
}
