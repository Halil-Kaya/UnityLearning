using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saglik : MonoBehaviour
{
    //canı dışardan veriyorum
    [SerializeField] float can;

    //Zaral al fonksiyonu sayesinde objenin canını azaltıyorum
    public void ZaralAl(float zararMiktari) {

        can -= zararMiktari;
        //eğer can 0 ın altına girerse Saglık programına<scriptine> sahip obje yok oluyor
        if(can <= 0) {

            Destroy(gameObject);

        }

    }


}
