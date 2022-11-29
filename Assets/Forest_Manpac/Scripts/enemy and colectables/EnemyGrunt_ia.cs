using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyGrunt_ia : MonoBehaviour{

    public NavMeshAgent _Agent;
    public Transform MinDist;
    public Vector3 moveTo;

    void Agent(){        
    _Agent.SetDestination(moveTo);        
    }
    void mover(){
    moveTo=MinDist.position;
    }

    void Awake() {
        mover();
        }
    void Update(){
        Agent(); 
        mover();
        }
     

}
