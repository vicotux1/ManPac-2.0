using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationY : MonoBehaviour{
    [SerializeField][Range(-15f, 15f)]float rotationY;
    [SerializeField] Vector3 Rotation;

    void FixedUpdate(){ 
        XYZRotation();
        }
        void XYZRotation(){
         //transform.Rotate(0, rotationY, 0, Space.Self);
         transform.Rotate(Rotation); 
         }

}
