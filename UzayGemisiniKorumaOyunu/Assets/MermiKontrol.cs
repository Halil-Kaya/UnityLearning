using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiKontrol : MonoBehaviour{

    [SerializeField] float hasarVermeDegeri = 10f;


    private void OnTriggerEnter2D(Collider2D collision){
        //eğer mermi mermiye çarparsa mermiyi yok ediyorum
        if(collision.CompareTag("dusmaninMermisi") || collision.CompareTag("gemininMermisi")){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }

    //bu fonksiyon cagrildiginda mermiyi yok ediyorum
    public void YokOl() {
        Destroy(gameObject);
    }

    //bu fonksiyon merminin ne kadar hasar verdigini float olarak donduruyor
    public float ZararVer() {
        return hasarVermeDegeri;
    }



}
