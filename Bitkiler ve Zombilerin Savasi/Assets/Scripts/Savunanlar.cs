using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savunanlar : MonoBehaviour
{
    //objenin maliyeti
    public int maliyet;

    //parayi kontrol eden sciptimden bir obje oluşturuyorum
    private ParayiTopla paraKazanma;


    private void Start()
    {
        //bütün objelerimin arasından ParayiTopla programını buluyorum
        paraKazanma = GameObject.FindObjectOfType<ParayiTopla>();
    }

    //ay ciceğimiz bellirli sürede para kazandırıyor bu fonksiyon ay ciceginin animasyonunda otomatik olarak çağrılıyor
    public void ParayiAttir(int miktar) {

        paraKazanma.ParayiEkle(miktar);

    }

}
