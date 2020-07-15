using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermiler : MonoBehaviour
{

    // <*!*>

    //merminin hizini belirliyorum
    [SerializeField] float mermiHizi;
    //merminin verdigi zarari belirliyorum
    [SerializeField] float verdigiZarar;


    void Update()
    {
        //mermiye şu yönde haraket etmesini söylüyoruz bunu her frame de yaptığı için hareket etmiş gibi gözüküyor
        transform.Translate(Vector3.right*mermiHizi*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //eğer mermimiz bir objeye çarparsa bu fonksiyon tetiklenecek


        //mermimiz Saldıranlar programına<scriptine> sahip bir objeye mi çarptı? çarptığı objenin 
        //sağlığını kontrol eden Saglık programına<scriptine> sahip mi?
        //bunları öğrenmek için bir değişkine atıyorum eğer yoksa değişkene null atıyacak


        Saldiranlar saldiranObje = collision.gameObject.GetComponent<Saldiranlar>();
        Saglik saldiranObjeninSagligi = collision.gameObject.GetComponent<Saglik>();

        //eğer saldıran obje ve saldıranObjeninSağligi objesi null ise düşmana çarpmamıştır(mermi mermiye çarpmış olabilir)
        //eğer objeler null değil ise if bloğu çalışıcak
        if(saldiranObje && saldiranObjeninSagligi) {
            //merminin saldırdığı değdiği objeinin canını azaltıyorum
            saldiranObjeninSagligi.ZaralAl(verdigiZarar);
            //mermiyi yok ediyorum
            Destroy(gameObject);

        }



    }


}
