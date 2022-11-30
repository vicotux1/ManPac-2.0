using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour{
    public float gravity = 20.0F;   
    CharacterController controller;

        void Awake() {
        controller = GetComponent<CharacterController>(); 
    }
    void Update() {
        _gravity();
     }   
        
     void _gravity() {
        if (!controller.isGrounded) { 
                 controller.SimpleMove(Vector3.down*gravity * Time.deltaTime);
           }else {  
        }
         controller.SimpleMove(Vector3.zero* Time.deltaTime);
    }
}
