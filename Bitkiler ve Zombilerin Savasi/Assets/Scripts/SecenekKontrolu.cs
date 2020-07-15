using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecenekKontrolu : MonoBehaviour
{
    //Secenekler ekranımda bulunan objem bu ekranda ses ve zorluk seviyesini değiştiriyorum
    //başlangıçta var olan değerleri göstermek için ayriyetten oyuncu değerleri değiştirebilmesi için slider oluşturdum
    [SerializeField] Slider sesAyari;
    [SerializeField] Slider zorlukAyari;
    
    //sesi ayarlamak için müziği kontrol eden objemi alıyorum
    private MuzikKontrolu muzikYoneticisi;
    //önceki sahnelere dönek için sahne kontrolu objemi alıyorum
    private SahneKontrolu sahneKontrolu;

    private void Start()
    {
       //sliderlerin değerlerini daha önce ne ise onu ayarlıyorum
        sesAyari.value = OyuncuAyarlari.getAnaSes();
        zorlukAyari.value = OyuncuAyarlari.ZorluguAl();

        //objelerimi buluyorum
        muzikYoneticisi = GameObject.FindObjectOfType<MuzikKontrolu>();
        sahneKontrolu = GameObject.FindObjectOfType<SahneKontrolu>();
    }

    private void Update()
    {
        //sesi durmadan güncelliyorum böylece oyuncu sesi değiştirirse farkı gözlemliyebliecek
        muzikYoneticisi.SesiAyarla(sesAyari.value);    
    }


    public void kaydetVeCik() {
        //sesi ve zorluğu kaydedip oyuncuyu menuye yonlendiriyorum
        OyuncuAyarlari.AnaSesiAyarla(sesAyari.value);
        OyuncuAyarlari.ZorluguAyarla(zorlukAyari.value);
        sahneKontrolu.AdiylaSahneyeGit("Menu");
    }

    //başlangıç ayarlarına dönüyorum
    public void baslangicAyarlarinaDon() {

        sesAyari.value = 0.5f;
        zorlukAyari.value = 3f;

    }



}
