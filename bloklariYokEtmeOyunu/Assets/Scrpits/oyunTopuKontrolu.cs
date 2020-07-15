using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyunTopuKontrolu : MonoBehaviour
{

    public OyunBariKontrolu oyunBari;
    public float topunHizi;
    private bool oyunBasladiMi;
    private Vector3 topIleBarArasindakiMesafe;

    // Start is called before the first frame update
    void Start(){
        topIleBarArasindakiMesafe = gameObject.transform.position - oyunBari.transform.position;
    }

    // Update is called once per frame
    void Update(){

        if (!oyunBasladiMi){

            gameObject.transform.position = oyunBari.transform.position + topIleBarArasindakiMesafe;

            if (Input.GetMouseButtonDown(0)){

                oyunBasladiMi = true;
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, topunHizi, 0f);

            }

        }

        

    }
}
