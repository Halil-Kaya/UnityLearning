using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaldiranObjeYarat : MonoBehaviour
{
    //düşmanlarımı saldıran objelerimi yaratan oluşturan program. 1.2.3.4. Yol objeleri bu scrpite sahip

    //neleri oluşturcak bunları belirtmem lazım
    [SerializeField] GameObject[] SaldiranObjelerinPrefabi;

    
    void Update()
    {
        //rastgele düşman karakteri rastgele sürede üretmesi için yazdığım program
        foreach (GameObject saldiranObjeninPrefabi in SaldiranObjelerinPrefabi ) {

            
            if (SaldiriVaktiMi(saldiranObjeninPrefabi)) {

                SaldiranObjeyiYolaYerlestir(saldiranObjeninPrefabi);

            }


        }

    }

    private void SaldiranObjeyiYolaYerlestir(GameObject saldiranObje) {
        //saldıran objeyi oluşturuyorum
        GameObject olusanSaldiriObjesi = Instantiate(saldiranObje);
        //bu obje oluştuğu objenin(yolun) altında oluşmasını söylüyorum
        olusanSaldiriObjesi.transform.parent = transform;
        //yolun konumunda oluşmasını söylüyorum
        olusanSaldiriObjesi.transform.position = transform.position;

    }


    private bool SaldiriVaktiMi(GameObject saldiranObje) {

        //saldırı yapan programı alıyorum bu program üzrinden dogma suresini alıcam
        Saldiranlar saldiriYapanProgram = saldiranObje.GetComponent<Saldiranlar>();

        //eğer nesnem boş ise burda bir terslik var demektir çünkü sadece düşmanların dogma süresi var yani geliştirici
        //düşman niyetine alakasız bir şeyi oluşturmaya çalışıyor
        if (saldiriYapanProgram) {

            //bekleme suresini aliyorum
            float dogmaBeklemeSuresi = saldiriYapanProgram.dogmaSuresi;
            //bekleme oranini hesaplama yapmak için bir orana dönüştürüyorum
            float dogmaBeklemeOrani = 1 / dogmaBeklemeSuresi;

            //burda rastgele olması için bir oran oluşturuyorum eğer bu oluşan oran random sayıdan büyük ise düşman oluşturcak
            float sonOran = dogmaBeklemeOrani * Time.deltaTime;
            if (Random.value < sonOran)
            {
                return true;
            }

        }else
        {
            Debug.Log("hata savunan bir objeyi düşman olarak olarak oluşturmaya çalışıyorsun saldiranObjeninPrefabi dizisinin içini kontrol et");
        }



        return false;

    }


}
