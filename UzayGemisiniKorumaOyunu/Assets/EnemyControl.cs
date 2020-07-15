using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    [SerializeField] float dusmaninCani = 100f;
    [SerializeField] GameObject dusmaninMermisi;
    [SerializeField] float mermininHizi = 1f;
    [SerializeField] float mermiAtmaAraligi = 1f;
    [SerializeField] int skorDegeri = 100;

    private SkorKontrol skorKontrolu;

    private void Start()
    {
        skorKontrolu = GameObject.Find("Skor").GetComponent<SkorKontrol>();
    }

    //Mermim gemiye carptiginda calisacak yer
    private void OnTriggerEnter2D(Collider2D collision){

        if (collision.gameObject.CompareTag("gemininMermisi")) { 

        //mermimi bir objeye atiyorum
        MermiKontrol mermi = collision.gameObject.GetComponent<MermiKontrol>();
        
            //dusmanin canini azaltiyorum
            dusmaninCani -= mermi.ZararVer();
            //dusmana carptiktan sonra mermiyi yok ediyorum
            mermi.YokOl();

            //eger dusmanin cani 0 dan az ise dusman gemisini yok ediyorum
            if (dusmaninCani <= 0) {
                skorKontrolu.skorAttir(skorDegeri);
                Destroy(gameObject);

            }
        }


    }

    private void AtesEt() {
        GameObject olusanMermi = Instantiate(dusmaninMermisi, transform.position, Quaternion.identity) as GameObject;
        olusanMermi.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -mermininHizi, 0);
    }

    void Update(){

        //random bir sekilde ates etsin diye yazdigim bir olasilik
        var atmaAraligi = Time.deltaTime * mermiAtmaAraligi*Random.value;
        if(atmaAraligi < 0.0008f) {
            AtesEt();
        }
        
        
    }

}
