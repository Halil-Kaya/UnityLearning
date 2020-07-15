using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilki : MonoBehaviour
{

    //tilkinin animasyonlarını kontrol etmek için onun animatorunu tutacak bir nesne oluşturuyorum
    private Animator tilkiAnimator;

    //neye saldirdigini belirtmek için saldiranlar objesine ulaşmam lazım bu yüzden bunu tutacak bir obje oluşturuyorum
    private Saldiranlar saldiranObje;

    // Start is called before the first frame update
    void Start()
    {
        //objeleri bulup eşitliyorum
        tilkiAnimator = GetComponent<Animator>();
        saldiranObje = GetComponent<Saldiranlar>();

    }


    private void OnTriggerEnter2D(Collider2D collision){
        //eğer tilki bir objeyle etkileşime girerse bu fonksiyon tetiklenecek

        GameObject tilkininEtkilisimeGirdigiObje = collision.gameObject;

        //eğer tilkinin etkilişime girdiği obje savunanlar scriptine sahip bir obje değilse bir işlem yapmıyorum
        if (!tilkininEtkilisimeGirdigiObje.GetComponent<Savunanlar>()) {

            return;


        }//eğer etkilişime girdiği obje taş ise tilkiye tek seferlik oynatılacak olan zıplama animasyonunu yapmasını söylüyorum
        else if (tilkininEtkilisimeGirdigiObje.GetComponent<Tas>()) {

            tilkiAnimator.SetTrigger("onuneTasGeldi");

        }else {
            //eğer saldırdığı bir obje ise tilkiye saldirma animasyonunu başlatmasını söylüyorum
            tilkiAnimator.SetBool("saldiriyorMu",true);
            //tilkinin neye saldırdığını belirtiyorum
            saldiranObje.HedefiBelirle(tilkininEtkilisimeGirdigiObje);
        }


    }


}
