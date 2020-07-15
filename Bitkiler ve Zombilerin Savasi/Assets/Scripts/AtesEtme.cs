using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtesEtme : MonoBehaviour
{

    //hem kaktus hemde cuce bu sinifi kullaniyor ikisi de ates ediyor ama ikisininde ates ettigi mermi farkli
    //bu yuzden mermi nesnesinde atacagi nesneyi giriyor
    [SerializeField] GameObject mermi;

    //mermi nesneye gore neresinden cikacak buraya o objeyi koyuyoruz boylece merminin cikis noktasini ayarliyabiliyoruz
    [SerializeField] GameObject mermininCikmanoktasi;

    //ates eden objenin(Savunan obje) animasyonlarini kontrol etmek icin animator objesini aliyoruz
    private Animator savunaninAnimatoru;

    //nesnenin hangi yola koyuldugu,dusmanin o yoldan mi geldigini kontrol etmek icin saldiranObjeYarat objesinin altındaki objeleri donerek kontrol yapıyorum
    private SaldiranObjeYarat SaldiriYolu;

    //olusan mermi dosyalarda karışık olarak eklenmesin belli bir duzene gore eklensin diye koydugum obje
    private GameObject mermiParent;

    private void Start()
    {
        //objemizin nere konuldugunu buluyoruz
        SaldiranObjeninYolunuBelirleme();

        //savunan objenin animatorunu aliyoruz
        savunaninAnimatoru = GetComponent<Animator>();


        //bu objemiz eger objeler arasında Mermiler diye bir obje bulamazsa null degeri döndürecek
        mermiParent = GameObject.Find("Mermiler");

        //eğer Mermiler objesi null ise buraya girecek
        if (!mermiParent) {

            //Mermiler adinda bir obje olusturduk unity de bakarsan bu objeyi görebilirsin
            mermiParent = new GameObject("Mermiler");

        }
        
    }

    private void Update()
    {
        //durmadan kontrol ediyorum

        //saldiran objemiz yani düşmanımıza ateş etmelimiyiz onu kontrol ediyorum
        if (SaldiranYolaGirdiMi()) {

            //animasyon kısmında bir event ekledik
            //saldiriyorMu değişkeni true olduğunda bir animasyon devreye giriyor bu animasyonun ortasında da bir AtesEt fonksiyonu tetikleniyor
            //bu şekilde objemiz ateş ediyor yani animasyonun oynaması ateş etmesini sağlıyor
            savunaninAnimatoru.SetBool("saldiriyorMu",true);

        }
        else {

            //eğer ateş etmemesi gerekiyorsa saldiriyorMu değişkenini false yapıyoruz böylece objemiz rutin haraketini yapacak böylece
            //AtesEt fonksiyonu tetiklenmiyecek
            savunaninAnimatoru.SetBool("saldiriyorMu", false);

        }
        
    }


    public void AtesEt() {

        //bu fonksiyonumuzda ates ediyoruz bu fonksiyon çağrıldığında obje ateş ediyor
        //mermiyi atmak için objeden oluşturuyorum
        GameObject atilanMermi = Instantiate(mermi) as GameObject;
        //merminin nerde oluşçağını söylüyorum
        atilanMermi.transform.position = mermininCikmanoktasi.transform.position;
        //oluşan merminin hangi objenin altında olacağını söylüyorum
        atilanMermi.transform.parent = mermiParent.transform;

        //burda şunu sorabilirsin biz mermiye bir hız vermedik ona bir vektör atamadık peki mermi nasıl gidiyor?
        //bunun sebebi bizim oluşturdugumuz mermi nesnesinin içinde Mermi scripti var ve bu scripte mermiye hiz veriyor
        //yani mermi objesini oluşturuyoruz bu mermi objesinin içindeği Mermi programı<scripti> çalışıyor bu programın içinde de
        //mermiye yön ve hız veriyor

    }

    private void SaldiranObjeninYolunuBelirleme() {

        //1.2.3.4.5. Yol objeleri SaldiranObjeYarat programına sahip bu ortak noktalarını kullanarak onlardan bir dizi oluşturuyorum
        SaldiranObjeYarat[] oyundakiSaldiranObjelerinYollari = GameObject.FindObjectsOfType<SaldiranObjeYarat>();

        //bu diziyi dolaşıyorum
        foreach(SaldiranObjeYarat saldiranObjeninCiktigiYer in oyundakiSaldiranObjelerinYollari) { 
            
            //eğer ki objemizin bulunduğu y pozisyonu ile SaldıranObjeYarat programın içinde bulunduğu obje(1.2.3.4 Yol objesi)nin y pozisyonu aynıysa burayagirecek
            if(saldiranObjeninCiktigiYer.transform.position.y == transform.position.y) {

                //eğer y konumları aynıysa objemizin hangi konumda olduğunu bulmuş olduk
                //objelimize bu yolu eşitleyip fonksiyondan çıkıyoruz
                SaldiriYolu = saldiranObjeninCiktigiYer;
                return;

            }

        }



    }

    private bool SaldiranYolaGirdiMi() { 
        
        //eğer o SaldiriYolu<1.2.3.4 yol objelerinden 2.Yol objesine eşitlendi diyelim yani objemiz 2.Yol objesini tutuyor> objesinin altında çocuk yoksa
        //bu demek oluyor ki orda düşman yok bu yüzden ates etmemesi gerekiyor false dönüyor
        if(SaldiriYolu.transform.childCount <= 0) {

            return false; 

        }


        //eğer altında obje var(yani düşman var) ise bu seferde düşmanın sağda mı yoksa solda mı olduğunu kontrol etmemiz gerekmektedir
        //bunun sebebi savunan obje sağdaysa ve düşman soldaysa ateş etmemesi lazım
        //SaldiriYolu Objenin içindeki objeleri(düşman objelerini) dönüyorum
        foreach (Transform saldiranObje in SaldiriYolu.transform) { 

            //eğer düşman sağda ise ateş etmesini söylüyorum
            if(saldiranObje.transform.position.x > transform.position.x) {
                return true;
            }


        }

        //eğer düşman soldaysa yukardaki kod döngüsünde fonksiyon bitmeyecek bizim bu noktada objemizin ateş etmemesi lazım
        //o yüzden false dönüyorum
        return false;
    }

}
