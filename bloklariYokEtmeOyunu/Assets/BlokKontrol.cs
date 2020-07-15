using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlokKontrol : MonoBehaviour
{
    [SerializeField] int can;
    [SerializeField] Sprite[] blokGorunumleri;
    private int vurulmaSayisi;
    private static int blokSayisi;


    // Start is called before the first frame update
    void Start(){
        blokSayisi++;
        vurulmaSayisi = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision){

        vurulmaSayisi++;

        if(vurulmaSayisi >= can) {

            blokSayisi--;
            Destroy(gameObject);
            if(blokSayisi <= 0) { 
            GameObject.FindObjectOfType<SahneKontrolu>().sonrakiSahne();
            }
        }
        else{

            this.GetComponent<SpriteRenderer>().sprite = blokGorunumleri[vurulmaSayisi - 1];

        }



    }

}
