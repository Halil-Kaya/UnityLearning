using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunBariKontrolu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        Vector3 oyunBariKonumu = new Vector3(0f,this.transform.position.y,0f);
        float mouseKonumuX = Input.mousePosition.x / Screen.width * 16;
        oyunBariKonumu.x = Mathf.Clamp(mouseKonumuX,0f,14f);
        this.transform.position = oyunBariKonumu;

    }
}
