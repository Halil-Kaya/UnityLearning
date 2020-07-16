using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Transform playerTransform;
    [SerializeField] float max,min;    


    // Start is called before the first frame update
    private void Start() {
        playerTransform = GameObject.Find("Player").transform;    
    }

    // Update is called once per frame
    void Update(){
    Debug.Log("worked");
     transform.position = new Vector3(Mathf.Clamp(playerTransform.position.x,min,max),transform.position.y,transform.position.z);   
    }
}
