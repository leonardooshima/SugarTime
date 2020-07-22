using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour{
    
    public GameObject player;
    //ivate Transform lookAt;
    private Vector3 offset;
    private Vector3 moveVector; 
    
    void Start(){
        offset = transform.position - player.transform.position;
    }
    
    void Update(){
        moveVector =  player.transform.position + offset;
        
        //X
        moveVector.x = Mathf.Clamp(moveVector.x, (-2), (10));
        //Y
        moveVector.y = Mathf.Clamp(moveVector.y, -2, 2);
            
        transform.position = moveVector;
    }
}