using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest_Controller : MonoBehaviour{
    [SerializeField]SoundFXManagerv FXManager;
    [SerializeField] Transform MeshPlayer;
    private Vector3 moveDirection = Vector3.zero;
    [SerializeField][Range(0.001f, 20.0f)]
    float Speed=0.1f,SpeedRun;
    [SerializeField]bool Is_SideScroll;
    [SerializeField]AudioClip Foot;
   [SerializeField]bool CursorIsvisble=false;
    [SerializeField]string Horizontal, Vertical, Run;
    [SerializeField]int _Sound;
    
    private  CharacterController _controller;
    
    float Axis_Horizontal, Axis_Vertical;
    Animator _anim;
    
    private void Awake(){
        _controller=GetComponent<CharacterController>();
        _anim=gameObject.GetComponent<Animator>();
        if(FXManager==null){
        FXManager=FindObjectOfType<SoundFXManagerv>();       
       }
     }
    void Update(){
        Axis_Horizontal=Input.GetAxis(Horizontal);
        if (Is_SideScroll==true) { 
            Axis_Vertical=-Input.GetAxis(Vertical);
           }  else { 
            Axis_Vertical=Input.GetAxis(Vertical);
           }

        Movement(Axis_Horizontal,Axis_Vertical);
        Cursor.visible = CursorIsvisble;
        SoundWalk();
    } 

        void Movement(float vertical, float horizontal){ 
        Vector3 Move=new Vector3(horizontal,0,vertical);
        Move.Normalize();            
            if(Input.GetButton(Run)){               
                _anim.SetBool("Runner", true); 
                _anim.SetFloat("IsRunV",Mathf.Abs(Axis_Vertical));
                _anim.SetFloat("IsRunH",Mathf.Abs(Axis_Horizontal)); 
                _controller.Move(Move * Time.deltaTime * SpeedRun); 
            }
            else{ 
                _anim.SetBool("Runner",false); 
                _anim.SetFloat("SpeedV",Mathf.Abs(Axis_Vertical));
                _anim.SetFloat("SpeedH",Mathf.Abs(Axis_Horizontal));
                _controller.Move(Move * Time.deltaTime * Speed);  
        }
        Rotate(Move);      
    } 
    void Rotate(Vector3 move){
        Vector3 Rotation=new Vector3 (move.x,0, move.z);        
         if (Axis_Horizontal!=0 || Axis_Vertical!=0){
          MeshPlayer.rotation= Quaternion.LookRotation(Rotation);
        }
    }
    void SoundWalk(){
        bool hasHorizontalInput = !Mathf.Approximately (Axis_Vertical, 0f);
        bool hasVerticalInput = !Mathf.Approximately (Axis_Horizontal, 0f);        
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        if (isWalking && _controller.isGrounded){
            FXManager.SoundPlay(Foot,_Sound);
        } else { 
            FXManager.SoundStop(Foot,_Sound);
           }
    } 
}
