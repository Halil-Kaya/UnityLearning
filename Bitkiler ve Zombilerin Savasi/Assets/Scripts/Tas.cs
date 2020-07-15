using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tas : MonoBehaviour
{
    //tasin animasyonunu kontrol etmek için animator nesnesi oluşturuyorum
    private Animator tasinAnimasyonu;

    private void Start()
    {
        //tas objemin icinde bulunan animatoru tutuyorum
        tasinAnimasyonu = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision){
        //eğer tas bir obje ile etkileşime girerse bu fonksiyon devreye girecek

        //eğer taşın etkilişeme girdiği objenin tagi tilki veya mermi değilse saldırıyorMu değişkenini true yapıyorum böylece taşım 
        //saldırıya uğruyormuş gibi gözüküyor
        if(!collision.gameObject.CompareTag("Tilki") && !collision.gameObject.CompareTag("Mermi")) {

            tasinAnimasyonu.SetBool("saldiriyorMu",true);

        }

    }

    //taşın alanından bir obje çıktığında yani artık etrafında bir obje olmadığında bu obje çalışıyor
    private void OnTriggerExit2D(Collider2D collision){

        //artık yanında bir şey olmadığına göre saldiriyorMu değişkenini false yapıyorum
        tasinAnimasyonu.SetBool("saldiriyorMu", false);
    
    }


}
