using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLimit : MonoBehaviour{
    
    [SerializeField]string TagJugador;
    [SerializeField]GameManager GameManager;
    public GameObject Player;
    public Vector3 Destino;
    public LevelManagerText levelManagerText;

    void Awake(){
      if(GameManager==null){
        GameManager=FindObjectOfType<GameManager>();
        Player=GameObject.FindGameObjectWithTag(TagJugador); 
        //levelManagerText.Dead(GameManager.lives);
        }
      }
      void OnTriggerEnter(Collider other){
		if (other.tag == TagJugador){
        GameManager.lives--;
        Player.transform.position=Destino;
        }
    } 
  } 
